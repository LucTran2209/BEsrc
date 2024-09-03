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
		public string RoomType { get; set; } 
		public int Capacity { get; set; } 
		public int Floor { get; set; } 
		public bool IsAvailable { get; set; } 
		public decimal Area { get; set; } 
		public string Equipment { get; set; } 
		public string Image { get; set; } 
		public string Notes { get; set; } 

		// Foreign key to Building entity
		//public Guid BuildingId { get; set; } 

		// Navigation property for the Building
		//public virtual Building Building { get; set; } 

	}
}
