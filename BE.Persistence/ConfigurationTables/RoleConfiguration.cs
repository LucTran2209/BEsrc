using BE.Domain.Entities.Roles;
using BE.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE.Persistence.ConfigurationTables
{
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Set Table Name
            builder.ToTable(ConstantTableNames.Roles);

            //Set Primary Key
            builder.HasKey(x => x.Id);


            // Set Foreign Key
            //builder.HasMany(e => e.UserRoles)
            //      .WithOne()
            //      .HasForeignKey(ut => ut.RoleId)
            //      .IsRequired();

            //Set Property in table
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.RoleName)
                   .IsRequired()
                   .HasMaxLength(50);


            builder.Property(e => e.RoleDescription)
                   .IsRequired(false)
                   .HasMaxLength(200);

        }
    }
}
