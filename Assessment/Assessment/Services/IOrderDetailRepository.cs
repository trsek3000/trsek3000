using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Services
{
   public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetail(int? OrderDetailId);
        Task<int> AddOrderDetail(OrderDetail orderDetails);
        Task<int> DeleteOrderDetail(int? OrderDetailId);
        Task UpdateOrderDetail(OrderDetail orderDetail, int id);
    }
}
