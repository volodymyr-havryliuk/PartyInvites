using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Data
{
    public class PartyInvitesContext : DbContext
    {
        public PartyInvitesContext(DbContextOptions<PartyInvitesContext> options) : base(options)
        {
        }

        public DbSet<GuestResponse> GuestResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestResponse>().ToTable("GuestResponse");
        }
    }
}
