using BE.Domain.Entities.Buildings;
using BE.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE.Persistence.ConfigurationTables
{
    internal sealed class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            // Set Table Name
            builder.ToTable(ConstantTableNames.Buildings);

            //Set Primary Key
            builder.HasKey(x => x.Id);


            // Set Foreign Key


            //Set Property in table
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.BuildingName)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(e => e.Address)
                   .IsRequired(false)
                   .HasMaxLength(250);

            builder.Property(e => e.NumberOfFloor)
                  .IsRequired();

            builder.Property(e => e.YearConstucted)
                    .IsRequired();

            builder.Property(e => e.BuildingType)
                   .IsRequired(false)
                   .HasMaxLength(50);

            builder.Property(e => e.ManagerName)
                   .IsRequired(false)
                   .HasMaxLength(100);

            builder.Property(e => e.ContactNumber)
                   .IsRequired(false)
                   .HasMaxLength(100);

            builder.Property(e => e.EmergencyContact)
                   .IsRequired(false)
                   .HasMaxLength(50);

            builder.Property(e => e.Capacity)
                   .IsRequired();

            builder.Property(e => e.Image)
                   .IsRequired(false);


            builder.Property(e => e.IsValiable)
                   .IsRequired();

            builder.Property(e => e.Notes)
                   .IsRequired(false);
        }
    }
}
