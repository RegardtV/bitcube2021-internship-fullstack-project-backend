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
        IEnumerable<AdvertViewModel> GetAllAdverts();
        AdvertViewModel GetAdvertById(int advertId);
        IEnumerable<ProvinceViewModel> GetAllProvinces();
        IEnumerable<CityViewModel> GetAllCities();
        IEnumerable<CityViewModel> GetAllProvinceCities(int provinceId);
    }

    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _repo;
        private readonly IAdvertValidator _validator;
        private readonly IAdvertMapper _mapper;

        public AdvertService(IAdvertRepository repo, IAdvertValidator validator, IAdvertMapper mapper)
        {
            _repo = repo;
            _validator = validator;
            _mapper = mapper;
        }

        public IEnumerable<AdvertViewModel> GetAllAdverts()
        {
            var entityList = _repo.GetAllAdverts();
            return entityList.Select(advert => _mapper.ViewMapper(advert));
        }

        public AdvertViewModel GetAdvertById(int advertId)
        {
            var entity = _repo.GetAdvertById(advertId);
            
            if (entity == null)
                throw new NotFoundApiException("Advert does not exist");

            return _mapper.ViewMapper(entity);
        }

        public IEnumerable<ProvinceViewModel> GetAllProvinces()
        {
            var entityList = _repo.GetAllProvinces();
            return entityList.Select(province => _mapper.ProvinceMapper(province));
        }

        public IEnumerable<CityViewModel> GetAllCities()
        {
            var entityList = _repo.GetAllCities();
            return entityList.Select(city => _mapper.CityMapper(city));
        }

        public IEnumerable<CityViewModel> GetAllProvinceCities(int provinceId)
        {
            var entityList = _repo.GetAllProvinceCities(provinceId);
            return entityList.Select(city => _mapper.CityMapper(city));
        }
    }
}