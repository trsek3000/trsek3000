using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Services
{
  public  interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int? UserId);
        Task<User> Login(User users);
        Task<int> AddUser(User users);
        Task<int> DeleteUser(int? UserId);
        Task UpdateUser(User user, int id);
    }
}
