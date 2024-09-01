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
		// Kiểm tra xem có phòng nào với RoomName cụ thể không
		var roomName = "Room A101";
		var room = await context.Rooms.SingleOrDefaultAsync(r => r.RoomName == roomName);

		if (room == null)
		{
			// Nếu phòng chưa tồn tại, tạo phòng mới
			room = new Room()
			{
				Id = Guid.NewGuid(),
				RoomName = roomName,
				RoomDescription = "Lecture room on the first floor",
			};

			await context.Rooms.AddAsync(room);
		}

		await context.SaveChangesAsync();
	}
}
