using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.DataAccess.Data.Contexts
{
    public class AdministationDbContext : DbContext
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }

        public AdministationDbContext(DbContextOptions<AdministationDbContext> options) : base(options)
        {
        }
    }
}
