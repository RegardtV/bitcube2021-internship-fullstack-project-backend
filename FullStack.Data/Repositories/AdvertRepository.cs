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
        List<Advert> GetAllUserAdverts(int userId);
        Advert GetUserAdvertById(int userId, int advertId);
        Advert CreateUserAdvertById(Advert advert);
        void UpdateUserAdvertById(Advert advert);
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

        public List<Advert> GetAllUserAdverts(int userId)
        {
            return _ctx.Adverts.Where(ad => ad.UserId == userId).ToList();
        }

        public Advert GetUserAdvertById(int userId, int advertId)
        {
            return _ctx.Adverts
                .Where(adv => adv.UserId == userId && adv.Id == advertId).FirstOrDefault();
        }

        public Advert CreateUserAdvertById( Advert advert)
        {
            _ctx.Adverts.Add(advert);
            _ctx.SaveChanges();
            return advert;
        }

        public void UpdateUserAdvertById(Advert advert)
        {
            _ctx.Adverts.Update(advert);
            _ctx.SaveChanges();
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
