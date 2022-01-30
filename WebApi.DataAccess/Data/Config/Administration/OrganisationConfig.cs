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
    class OrganisationConfig : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.ToTable("Organisations");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(Organisation.NameMaxLength).IsRequired();

            builder.HasMany<User>(o => o.Users)
                   .WithMany(u => u.Organisations)
                   .UsingEntity<Membership>(
                       right => right.HasOne(m => m.User).WithMany().HasForeignKey(m => m.UserId),
                       left => left.HasOne(m => m.Organisation).WithMany().HasForeignKey(m => m.OrganisationId),
                       join => join.ToTable("OrganisationMembers")
                   );
            //builder.HasMany<User>(o => o.Users)
            //       .WithMany(u => u.Organisations)
            //       .UsingEntity(
            //           join => join.ToTable("OrganisationMembers").HasData(
            //            new[] 
            //                {
            //                    new { OrganisationsId = Guid.Parse(UtilsConfig.DevOrganisationId), UsersId = Guid.Parse(UtilsConfig.AdminUserId)},
            //                    new { OrganisationsId = Guid.Parse(UtilsConfig.ManagerOrganisationId), UsersId = Guid.Parse(UtilsConfig.AdminUserId)},
            //                    new { OrganisationsId = Guid.Parse(UtilsConfig.SalesOrganisationId), UsersId = Guid.Parse(UtilsConfig.AdminUserId)},

            //                }));

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasData(
                new Organisation
                {
                    Id = Guid.Parse(UtilsConfig.DevOrganisationId),
                    Name = UtilsConfig.DevOrganisationName
                },
                new Organisation
                {
                    Id = Guid.Parse(UtilsConfig.ManagerOrganisationId),
                    Name = UtilsConfig.ManagerOrganisationName
                },
                new Organisation
                {
                    Id = Guid.Parse(UtilsConfig.SalesOrganisationId),
                    Name = UtilsConfig.SalesOrganisationName
                });
        }
    }
}
