using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Services
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
      
            AssessmentDetailContext db;
            public OrderDetailRepository(AssessmentDetailContext _db)
            {
                db = _db;
            }

            public async Task<int> AddOrderDetail(OrderDetail orderDetail)
            {
                if (db != null)
                {
                    await db.orderDetails.AddAsync(orderDetail);
                    await db.SaveChangesAsync();

                    return 0;
                }
                return 0;
            }

            public async Task<int> DeleteOrderDetail(int? OrderDetailId)
            {
                int result = 0;

                if (db != null)
                {

                    var cl = await db.orderDetails.FirstOrDefaultAsync(x => x.OrderDetailId == OrderDetailId);

                    if (cl != null)
                    {

                        db.orderDetails.Remove(cl);

                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }
                return result;
            }

            public async Task<List<OrderDetail>> GetAllOrderDetails()
            {
                if (db != null)
                {
                    return await db.orderDetails.ToListAsync();
                }

                return null;
            }

        public async Task<OrderDetail> GetOrderDetail(int? OrderDetailId)
            {
                if (db != null)
                {
                    return await (from p in db.orderDetails
                                  where p.OrderDetailId == OrderDetailId
                                  select new OrderDetail
                                  {
                                      OrderId = p.OrderId,
                                      ProductId = p.ProductId,
                                      Price = p.Price,
                                      Quantity = p.Quantity,

                                  }).FirstOrDefaultAsync();
                }

                return null;
            }

            public async Task UpdateOrderDetail(OrderDetail orderdetails, int id)
            {
                var m = db.orderDetails.Where(x => x.OrderDetailId == id).FirstOrDefault();
                if (m != null)
                {

                    m.Quantity = orderdetails.Quantity;
                    m.Price = orderdetails.Price;



                    db.orderDetails.Update(m);
                    await db.SaveChangesAsync();
                }
            }
        }
   
}
