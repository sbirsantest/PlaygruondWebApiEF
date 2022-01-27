using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models.Administration;

namespace WebApi.DataAccess.Data.Seeds.Administration
{
    static class InitialAdministrationSeed
    {
        const string DevOrganisationId = "00000000-0000-0000-0000-DE00000000DE";
        const string DevOrganisationName = "dev organisation";

        const string AdminUserId = "00000000-0000-0000-0000-AD00000000AD";
        const string AdminUserName = "admin user";
        const string AdminUserEmail = "admin@admin.com";

        public static ModelBuilder AddInitialAdministrationSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>().HasData(
                new Organisation
                {
                    Id = Guid.Parse(DevOrganisationId),
                    Name = DevOrganisationName
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse(AdminUserId),
                    Name = AdminUserName,
                    Email = AdminUserEmail
                });

            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    OrganisationId = Guid.Parse(DevOrganisationId),
                    UserId = Guid.Parse(AdminUserId)
                });

            return modelBuilder;
        }
    }
}
