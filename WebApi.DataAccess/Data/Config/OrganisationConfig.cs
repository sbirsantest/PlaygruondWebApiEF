using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.DataAccess.Data.Config
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
        }
    }
}
