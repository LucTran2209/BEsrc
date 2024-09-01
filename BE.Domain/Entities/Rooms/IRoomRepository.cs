using BE.Domain.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Rooms
{
	public interface IRoomRepository : IBaseRepository<Room, Guid>
	{
		//Get All Room
		IQueryable<Room> GetAll();

	}
}
