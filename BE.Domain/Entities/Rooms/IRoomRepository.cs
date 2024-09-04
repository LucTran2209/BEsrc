using BE.Domain.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Rooms
{
	public interface IRoomRepository : IBaseRepository<Room, int>
	{

		//Get All Room
		IQueryable<Room> GetAll();
		Task<Room> FindByIdAsync(int id);

	}
}
