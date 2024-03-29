﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Domain.Models;

namespace WebJourneys.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<IATACode> IATACodes { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(t => t.Transport);
            modelBuilder.Entity<IATACode>().HasKey(i => i.IATA);
            //modelBuilder.Entity<Transport>().HasNoKey();
        }

    }
}
