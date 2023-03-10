using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginRegister.Models;

namespace LoginRegister.ApiControllers
{
    public class UserController : ApiController
    {
        UsersEntities1 db = new UsersEntities1();
        public List<User> Get()
        {
            try
            {
                List<User> users = db.Users.ToList();
                return users;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public User Get(int id)
        {
            try
            {
                var user = db.Users.Where(USER => USER.id == id).FirstOrDefault();
                return user;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void PostUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void PutUser(User user)
        {
            User oldUser = db.Users.Where(old => old.id == user.id).FirstOrDefault();
            try
            {
                if (oldUser != null)
                {
                    oldUser.name = user.name;
                    oldUser.address = user.address;
                    oldUser.sex = user.sex;
                    oldUser.phone = user.phone;
                    oldUser.job = user.job;
                    oldUser.age = user.age;
                }
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        } 
        
        public void DeleteUser(int id)
        {
           var principal = db.Users.Where(user => user.id == id).FirstOrDefault();
            db.Users.Remove(principal);
            db.SaveChanges();
        }
    }
}
