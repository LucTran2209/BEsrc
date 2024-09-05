using BE.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE.Persistence.ConfigurationTables
{
	internal sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
			// Set Table Name
			builder.ToTable("Rooms");

			// Set Primary Key
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
					.ValueGeneratedOnAdd();

			// Set Property Constraints
			builder.Property(x => x.RoomName)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(x => x.RoomType)
				   .IsRequired()
				   .HasMaxLength(25); 

			builder.Property(x => x.Capacity)
				   .IsRequired();

			builder.Property(x => x.Floor)
				   .IsRequired();

			builder.Property(x => x.IsAvailable)
				   .IsRequired();

			builder.Property(x => x.Area)
				   .IsRequired()
				   .HasColumnType("decimal(5, 2)"); 

			builder.Property(x => x.Equipment)
				   .HasMaxLength(int.MaxValue); 

			builder.Property(x => x.Image)
				   .HasMaxLength(int.MaxValue); 

			builder.Property(x => x.Notes)
				   .HasMaxLength(int.MaxValue);

			// Set Foreign Key
			//builder.HasOne(x => x.Building)
			//	   .WithMany(b => b.Rooms) // Assuming the Building entity has a collection of Rooms
			//	   .HasForeignKey(x => x.BuildingId);

			builder.HasOne(x => x.Building)
				   .WithMany(b => b.Rooms) // Building có nhiều Rooms
				   .HasForeignKey(x => x.BuildingId)
				   .OnDelete(DeleteBehavior.Cascade);

		}
	}
}
