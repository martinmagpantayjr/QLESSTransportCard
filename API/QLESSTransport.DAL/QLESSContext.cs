using System;
using API.QLESSTransport.Models.Entities;
using Microsoft.EntityFrameworkCore;
using QLESSTransport.Models;

namespace QLESSTransport.DAL
{
    public class QLESSContext : DbContext
    {
        public QLESSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransportCard> TransportCards { get; set; }
        public DbSet<MrtFare> MrtFares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }
    }
}
