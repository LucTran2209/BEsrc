using BE.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Rooms
{
	public class RefreshToken : EntityAuditBase
	{
		public Guid RoomId { get; set; }
		public required string Token {  get; set; }
		public DateTime Expires { get; set; }
		public virtual Room? Room { get; set; }	
	}
}
