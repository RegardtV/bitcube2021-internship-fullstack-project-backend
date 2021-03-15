using FullStack.Data.Entities;
using FullStack.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Services
{
    public interface IUserMapper
    {
        User EntityMapper(UserRegisterModel model);
        UserViewModel ViewMapper(User entity);
        UserAuthenticateResponseModel AuthenticateMapper(User entity, string token);
    }
    public class UserMapper: IUserMapper
    {
        public User EntityMapper(UserRegisterModel model)
        {
            return new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };
        }

        public UserViewModel ViewMapper(User entity)
        {
            return new UserViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }

        public UserAuthenticateResponseModel AuthenticateMapper(User entity, string token)
        {
            return new UserAuthenticateResponseModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Token = token
            };
        }
    }
}


