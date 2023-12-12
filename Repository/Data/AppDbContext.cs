using System;
using Domain.Configurations;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Employee> Employees{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Employee>().HasData(
                        new Employee { Id = 1, FullName = "Kubra Memmedova",Address="Xalqlar",Age=25 },
                        new Employee { Id = 2, FullName = "Surac Ismayilov", Address = "Vasmoy", Age = 24 },
                        new Employee { Id = 3, FullName = "Pervin Mirzeyev", Address = "Yasamal", Age = 30 }
                      );

        }

    }
}

