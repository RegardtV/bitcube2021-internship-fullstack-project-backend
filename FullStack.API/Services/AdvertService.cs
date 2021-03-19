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
using FullStack.ViewModels.Adverts;

namespace FullStack.API.Services
{
    public interface IAdvertService
    {
        IEnumerable<AdvertViewModel> GetAllUserAdverts(int userId);
        AdvertViewModel GetUserAdvertById(int userId, int advertId);
        AdvertViewModel CreateUserAdvertById(int userId, AdvertCreateUpdateModel model);
        void UpdateUserAdvertById(int userId, int advertId, AdvertCreateUpdateModel model);
        IEnumerable<ProvinceViewModel> GetAllProvinces();
        IEnumerable<CityViewModel> GetAllCities();
        IEnumerable<CityViewModel> GetAllProvinceCities(int provinceId);
    }

    public class AdvertService : IAdvertService
    {
        private readonly IUserRepository _userRepo;
        private readonly IAdvertRepository _advertRepo;
        private readonly IAdvertValidator _validator;
        private readonly IAdvertMapper _mapper;

        public AdvertService(IAdvertRepository advertRepo, IUserRepository userRepo, IAdvertValidator validator, IAdvertMapper mapper)
        {
            _advertRepo = advertRepo;
            _userRepo = userRepo;
            _validator = validator;
            _mapper = mapper;
        }

        public IEnumerable<AdvertViewModel> GetAllUserAdverts(int userId)
        {
            var entityList = _advertRepo.GetAllUserAdverts(userId);
            return entityList.Select(advert => _mapper.ViewMapper(advert));
        }

        public AdvertViewModel GetUserAdvertById(int userId, int advertId)
        {
            if (_userRepo.GetUser(userId) == null)
                throw new NotFoundApiException("User does not exist");

            var entity = _advertRepo.GetUserAdvertById(userId, advertId);
            return _mapper.ViewMapper(entity);
        }

        public AdvertViewModel CreateUserAdvertById(int userId, AdvertCreateUpdateModel model)
        {
            // validation
            var results = _validator.Validate(model).ToArray();
            if (results.Length > 0)
                throw new ValidationApiException(results);

            if (_userRepo.GetUser(userId) == null)
                throw new NotFoundApiException("User does not exist");

            var entity = _mapper.EntityMapper(model);
            entity.UserId = userId;
            entity = _advertRepo.CreateUserAdvertById(entity);
            return _mapper.ViewMapper(entity);
        }

        public void UpdateUserAdvertById(int userId, int advertId, AdvertCreateUpdateModel model)
        {
            // validation
            var results = _validator.Validate(model).ToArray();
            if (results.Length > 0)
                throw new ValidationApiException(results);

            if (_userRepo.GetUser(userId) == null)
                throw new NotFoundApiException("User does not exist");
            
            if (_advertRepo.GetUserAdvertById(userId, advertId) == null)
                throw new NotFoundApiException("Advert does not exist");

            var entity = _mapper.EntityMapper(model);
            entity.UserId = userId;
            entity.Id = advertId;
            _advertRepo.UpdateUserAdvertById(entity);
        }

        public IEnumerable<ProvinceViewModel> GetAllProvinces()
        {
            var entityList = _advertRepo.GetAllProvinces();
            return entityList.Select(province => _mapper.ProvinceMapper(province));
        }

        public IEnumerable<CityViewModel> GetAllCities()
        {
            var entityList = _advertRepo.GetAllCities();
            return entityList.Select(city => _mapper.CityMapper(city));
        }

        public IEnumerable<CityViewModel> GetAllProvinceCities(int provinceId)
        {
            var entityList = _advertRepo.GetAllProvinceCities(provinceId);
            return entityList.Select(city => _mapper.CityMapper(city));
        }
    }
}