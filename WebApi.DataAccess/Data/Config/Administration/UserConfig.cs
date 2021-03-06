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
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(User.NameMaxLength).IsRequired();
            builder.Property(e => e.Email).IsRequired();

            Seed(builder);
        }

        private static void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.Parse(UtilsConfig.AdminUserId),
                    Name = UtilsConfig.AdminUserName,
                    Email = UtilsConfig.AdminUserEmail
                });
        }

    }
}
