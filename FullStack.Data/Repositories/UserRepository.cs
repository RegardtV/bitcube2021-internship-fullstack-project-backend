using FullStack.Data.DbContexts;
using FullStack.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStack.Data.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        List<Advert> GetAllUserAdverts(int userId);
        Advert GetUserAdvertById(int userId, int advertId);
        Advert CreateUserAdvertById(Advert advert);
        void UpdateUserAdvertById(Advert advert);
    }
    public class UserRepository: IUserRepository
    {
        private readonly FullStackDbContext _ctx;
        public UserRepository(FullStackDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _ctx.Users.Find(id);
        }

        public User CreateUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return user;
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

        public Advert CreateUserAdvertById(Advert advert)
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
    }
}
