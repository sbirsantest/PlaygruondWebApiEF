using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models.Administration;

namespace WebApi.DataAccess.Data.Config.Administration
{
    class MembershipConfig : IEntityTypeConfiguration<Membership>
    {

        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Membership> builder)
        {
            builder.HasData(
                new Membership
                {
                    OrganisationId = Guid.Parse(UtilsConfig.DevOrganisationId),
                    UserId = Guid.Parse(UtilsConfig.AdminUserId)
                },
                new Membership
                {
                    OrganisationId = Guid.Parse(UtilsConfig.ManagerOrganisationId),
                    UserId = Guid.Parse(UtilsConfig.AdminUserId)
                },
                new Membership
                {
                    OrganisationId = Guid.Parse(UtilsConfig.SalesOrganisationId),
                    UserId = Guid.Parse(UtilsConfig.AdminUserId)
                });

        }

    }
}
