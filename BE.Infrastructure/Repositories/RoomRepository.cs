using BE.Domain.Entities.Rooms;
using BE.Infrastructure.Abstractions;
using BE.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infrastructure.Repositories
{
	public class RoomRepository : BaseRepository, IRoomRepository
	{
		public RoomRepository(ApplicationDbContext context) : base(context)
		{
		}

		public void Delete(Room entity)
		{
			context.Rooms.Remove(entity);
		}

		public async Task<Room> FindByIdAsync(Guid id)
		{
			var room = await context.Rooms.SingleOrDefaultAsync(r => r.Id == id);
			return room;
		}

		public IQueryable<Room> GetAll()
		{
			var query = context.Rooms
			   .AsQueryable();
			return query;
		}

		public async void Insert(Room entity)
		{
			await context.Rooms.AddAsync(entity);
		}

		public void Update(Room entity)
		{
			context.Rooms.Update(entity);
		}
	}
}
