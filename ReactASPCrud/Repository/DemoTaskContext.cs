using Microsoft.EntityFrameworkCore;
using ReactASPCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Repository
{
    public class DemoTaskContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public DemoTaskContext(DbContextOptions<DemoTaskContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
        }

    }
}
