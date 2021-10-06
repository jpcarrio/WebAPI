using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DBContext : DbContext
    {        
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
           
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            modelBuilder.Entity<ContactType>().HasData(
                   new ContactType { Id = 1, TypeName = "ContactType 1" },
                   new ContactType { Id = 2, TypeName = "ContactType 2" },
                   new ContactType { Id = 3, TypeName = "ContactType 3" }
                ); 
        }


        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
