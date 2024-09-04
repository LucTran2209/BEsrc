using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Services.Rooms.RoomServiceInputDto
{
	public class CreateRoomInputDto
	{
		public string RoomName { get; set; }
		public string RoomType { get; set; }
		public int Capacity { get; set; }
		public int Floor { get; set; }
		public bool IsAvailable { get; set; }
		public decimal Area { get; set; }
		public string Equipment { get; set; }
		public string Image { get; set; }
		public string Notes { get; set; }
	}
}
