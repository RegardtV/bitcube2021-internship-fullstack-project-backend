using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FullStack.API.Helpers;
using FullStack.ViewModels;
using FullStack.ViewModels.Users;
using FullStack.Data.Entities;
using FullStack.API.Exceptions;
using FullStack.Data.Repositories;
using FullStack.API.Helpers.Exceptions;

namespace FullStack.API.Services
{
    public interface IUserService
    {
        UserAuthenticateResponseModel Authenticate(UserAuthenticateRequestModel model);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(int id);
        UserViewModel Create(UserRegisterModel model);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IUserValidator _validator;
        private readonly IUserMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository repo, IUserValidator validator, IUserMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _validator = validator;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public UserAuthenticateResponseModel Authenticate(UserAuthenticateRequestModel model)
        {
            // validation
            var results = _validator.Validate(model).ToArray();
            if (results.Length > 0)
                throw new ValidationApiException(results);

            // get the user from the repository / database 
            var entity = _repo.GetUsers().SingleOrDefault(user => user.Email == model.Email && user.Password == model.Password);
            
            // throw unathorized exception if user doesn't exist
            if (entity == null)
            {
                throw new UnauthorizedApiException("Username or password is incorrect");
            }

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(entity.Id);

            //return the UserAuthenticateResponseModel to the controller
            return _mapper.AuthenticateMapper(entity, token);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var entityList = _repo.GetUsers();
            return entityList.Select(user => _mapper.ViewMapper(user));
        }

        public UserViewModel GetById(int id)
        {
            var entity = _repo.GetUser(id);
            if (entity == null)
            {
                throw new NotFoundApiException("User does not exist");
            }

            return _mapper.ViewMapper(entity);
        }

        public UserViewModel Create(UserRegisterModel model)
        {
            // validation
            var results = _validator.Validate(model).ToArray();
            if (results.Length > 0)
                throw new ValidationApiException(results);

            if (_repo.GetUsers().Any(user => user.Email == model.Email))
            {
                throw new DuplicateUserApiException("Email address already in use");
            }

            User entity = _mapper.EntityMapper(model);
            entity = _repo.CreateUser(entity);
            return _mapper.ViewMapper(entity);
        }

        // generate token that is valid for 7 days
        private string GenerateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
