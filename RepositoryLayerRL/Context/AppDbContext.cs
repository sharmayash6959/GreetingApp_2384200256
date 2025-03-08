using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<GreetingEntity> AllGreetings { get; set; }  // Table for Greeting messages
    }
}
