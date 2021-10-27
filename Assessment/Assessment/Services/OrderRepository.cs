using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Services
{
    public class OrderRepository : IOrderRepository
    {
        AssessmentDetailContext db;
        public OrderRepository(AssessmentDetailContext _db)
        {
            db = _db;
        }

        public async Task<int> AddOrder(Order orders)
        {

          
            if (db != null)
            {
                await db.orders.AddAsync(orders);
                await db.SaveChangesAsync();

                return orders.OrderId;
            }
            return 0;
        }

        public async Task<int> DeleteOrder(int? OrderId)
        {
            int result = 0;

            if (db != null)
            {

                var cl = await db.orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);

                if (cl != null)
                {

                    db.orders.Remove(cl);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            if (db != null)
            {
                return await db.orders.ToListAsync();
            }

            return null;
        }

        public Task<string> GetNewOrderNumber()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(int? OrderId)
        {
            if (db != null)
            {
                return await (from p in db.orders
                              where p.OrderId == OrderId
                              select new Order
                              {
                                  OrderNumber = p.OrderNumber,
                                  Amount = p.Amount,
                                  UserId = p.UserId,
                                  OrderDate = p.OrderDate,
                                  OrderStatus = p.OrderStatus,

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateOrder(Order orders, int id)
        {
            var m = db.orders.Where(x => x.OrderId == id).FirstOrDefault();
            if (m != null)
            {

                m.OrderStatus = orders.OrderStatus;



                db.orders.Update(m);
                await db.SaveChangesAsync();
            }
        }
    }
}

