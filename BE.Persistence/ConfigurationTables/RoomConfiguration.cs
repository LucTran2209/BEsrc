using BE.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			// Set Property Constraints
			builder.Property(x => x.RoomName)
				   .IsRequired()
				   .HasMaxLength(50);

			builder.Property(x => x.RoomDescription)
				   .HasMaxLength(200);


		}
	}
}
