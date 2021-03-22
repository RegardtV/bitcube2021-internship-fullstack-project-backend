using FullStack.Data.DbContexts;
using FullStack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStack.Data.Repositories
{
    public interface IAdvertRepository
    {
        List<Advert> GetAllAdverts();
        Advert GetAdvertById(int advertId);
        List<Province> GetAllProvinces();
        List<City> GetAllCities();
        List<City> GetAllProvinceCities(int provinceId);
    }
    public class AdvertRepository : IAdvertRepository
    {
        private readonly FullStackDbContext _ctx;
        public AdvertRepository(FullStackDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Advert> GetAllAdverts()
        {
            return _ctx.Adverts.ToList();
        }

        public Advert GetAdvertById(int advertId)
        {
            return _ctx.Adverts.Find(advertId);
        }

        public List<Province> GetAllProvinces()
        {
            return _ctx.Provinces.ToList();
        }

        public List<City> GetAllCities()
        {
            return _ctx.Cities.ToList();
        }

        public List<City> GetAllProvinceCities(int provinceId)
        {
            return _ctx.Cities.Where(ad => ad.ProvinceId == provinceId).ToList();
        }
    }
}
