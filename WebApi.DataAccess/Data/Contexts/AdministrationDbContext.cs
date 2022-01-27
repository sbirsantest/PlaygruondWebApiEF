using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.Data.Config;
using WebApi.Domain.Config;
using WebApi.Domain.Models;

namespace WebApi.DataAccess.Data.Contexts
{
    public class AdministrationDbContext : DbContext
    {
        private readonly GlobalConfig _config;

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }

        // constructor used at design time
        internal AdministrationDbContext(DbContextOptions<AdministrationDbContext> options) : base(options)
        {
        }

        public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options, GlobalConfig config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectString = GetConnectionString();
                optionsBuilder.UseSqlServer(connectString);

                //// for azure https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
                //optionsBuilder.UseSqlServer(connectString, sqlOptions =>
                //{
                //    sqlOptions.EnableRetryOnFailure(
                //    maxRetryCount: 5,
                //    maxRetryDelay: TimeSpan.FromSeconds(30),
                //    errorNumbersToAdd: null);
                //});
                //optionsBuilder.UseLoggerFactory(_loggerFactory);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected virtual string GetConnectionString()
        {
            return string.IsNullOrEmpty(_config.AdminDbPassword) ?
                _config.AdminDbConnectionString : $"Password=\"{_config.AdminDbPassword}\";{_config.AdminDbConnectionString}";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganisationConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
