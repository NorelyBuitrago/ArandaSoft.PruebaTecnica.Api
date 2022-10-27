using ArandaSoft.PruebaTecnica.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoft.PruebaTecnica.Repository.Data
{
    public class DbContexAplic : DbContext
    {
        public DbContexAplic(DbContextOptions<DbContexAplic> options) : base(options)
        {

        }





        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   
            modelBuilder.Entity<Product>()
                 .HasKey("Id"); 
            


        }

        public DbSet<Product> Product { get; set; }
    }
}
