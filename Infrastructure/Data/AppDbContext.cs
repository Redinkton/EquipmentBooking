using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceObject> ServiceObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceObject>().HasData(new ServiceObject
            {
                Id = Guid.NewGuid(),
                ServiceName = "Дрель",
                Amount = 2,
                Ok = true,
                Error = "a"

            }); ;
        }
    }
}
