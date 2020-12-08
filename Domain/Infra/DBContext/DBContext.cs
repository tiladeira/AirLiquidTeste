using Domain.Domain.Models;
using Domain.Domain.RepositoriesContracts.IBase;
using Domain.Infra.DBContext.Mappings;

using Microsoft.EntityFrameworkCore;

namespace Domain.Infra.DBContext
{
    public class DBContext : DbContext, ISystemContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Db = this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbContext Db { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}
