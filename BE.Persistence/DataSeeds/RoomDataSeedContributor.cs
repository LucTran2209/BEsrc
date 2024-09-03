using BE.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.DataSeeds;

public class RoomDataSeedContributor : IDataSeedContributor
{
	private readonly ApplicationDbContext context;

	public RoomDataSeedContributor(ApplicationDbContext context)
	{
		this.context = context;
	}

	public async Task SeedAsync()
	{
		if (await context.Rooms.AnyAsync()) return;

		IList<Room> rooms = new List<Room>()
			{
				new Room
				{
					Id = Guid.NewGuid(),
					RoomName = "BE-206",
					RoomType = "Classroom",
					Capacity = 30,
					Floor = 2,
					IsAvailable = true,
					Area = 25.5m,
					Equipment = "Projector, Board",
					Image = "BE-206.png",
					Notes = "Near the main entrance"
				}
            };

		await context.Rooms.AddRangeAsync(rooms);
		await context.SaveChangesAsync();
	}
}
