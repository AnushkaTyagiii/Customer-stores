using customers.Data_model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customers
{
    public class AppDbContext: DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Customer_storeapi;Trusted_Connection=True;Encrypt=False;");
        }

    }
}
