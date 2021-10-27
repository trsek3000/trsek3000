using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class AssessmentDetailContext:DbContext
    {

        public AssessmentDetailContext(DbContextOptions<AssessmentDetailContext> options) : base(options)
        { 

        }


        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }
}
