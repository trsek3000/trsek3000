using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Services
{
    public class UserRepository: IUserRepository
    {
        AssessmentDetailContext db;
        public UserRepository(AssessmentDetailContext _db)
        {
            db = _db;
        }

        public async Task<int> AddUser(User users)
        {
           
                await db.users.AddAsync(users);
                await db.SaveChangesAsync();

                return users.UserId;
            
            
        }

        public async Task<int> DeleteUser(int? UserId)
        {
            int result = 0;

            if (db != null)
            {

                var cl = await db.users.FirstOrDefaultAsync(x => x.UserId == UserId);

                if (cl != null)
                {

                    db.users.Remove(cl);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            if (db != null)
            {
                return await db.users.ToListAsync();
            }

            return null;
        }

        public async Task<User> Login(User user)
        {
            if (db != null)
            {
                return await (from p in db.users
                              where p.Username == user.Username
                              && p.Password ==user.Password
                              select new User
                              {
                                  UserId = p.UserId,
                                  Username = p.Username,

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<User> GetUser(int? UserId)
        {
            if (db != null)
            {
                return await (from p in db.users
                              where p.UserId == UserId
                              select new User
                              {
                                 UserId = p.UserId,
                                 Username = p.Username,

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateUser(User users, int id)
        {
            var m = db.users.Where(x => x.UserId == id).FirstOrDefault();
            if (m != null)
            {

                m.Username = users.Username;
                m.Password = users.Password;


                db.users.Update(m);
                await db.SaveChangesAsync();
            }
        }
    }
}
