using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Services
{
    public class ProductRepository:IProductRepository
    {
        AssessmentDetailContext db;
        public ProductRepository(AssessmentDetailContext _db)
        {
            db = _db;
        }

        public async Task<int> AddProduct(Product products)
        {
            if (db != null)
            {
                await db.products.AddAsync(products);
                await db.SaveChangesAsync();

                return products.ProductId;
            }
            return 0;
        }

        public async Task<int> DeleteProduct(int? ProductId)
        {
            int result = 0;

            if (db != null)
            {

                var cl = await db.products.FirstOrDefaultAsync(x => x.ProductId == ProductId);

                if (cl != null)
                {

                    db.products.Remove(cl);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            if (db != null)
            {
                return await db.products.ToListAsync();
            }

            return null;
        }

        public async Task<Product> GetProduct(int? ProductId)
        {
            if (db != null)
            {
                return await (from p in db.products
                              where p.ProductId == ProductId
                              select new Product
                              {
                                   ProductName = p.ProductName,
                                   Quantity = p.Quantity,
                                   Price = p.Price,
                                   Image = p.Image,

                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateProduct(Product products,int id)
        {
            var m = db.products.Where(x => x.ProductId == id).FirstOrDefault();
            if (m != null)
            {

                m.Quantity = products.Quantity;
                m.Price = products.Price;
               

                
                db.products.Update(m);
                await db.SaveChangesAsync();
            }
        }
    }
}
