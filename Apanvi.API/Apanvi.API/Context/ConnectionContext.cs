using Apanvi.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apanvi.API.Context
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) :base(options)
        { 
        }
        public DbSet<Animal> Animals{ get; set; }
        public DbSet<User> Users { get; set; }

    }
}

