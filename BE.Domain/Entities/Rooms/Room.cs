using BE.Domain.Abstractions;
using BE.Domain.Abstractions.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Rooms
{
	public class Room : EntityAuditBase, IEntityBase<Guid>
	{
		public Guid Id { get; set; }
		public string RoomName { get; set; }
		public string RoomDescription { get; set;}

	}
}
