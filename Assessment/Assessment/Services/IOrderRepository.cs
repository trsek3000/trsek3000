using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Services
{
  public  interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int? OrderId);
        Task<string> GetNewOrderNumber();
        Task<int> AddOrder(Order orders);
        Task<int> DeleteOrder(int? OrderId);
        Task UpdateOrder(Order order, int id);
    }
}
