﻿namespace BE.Domain.Abstractions.IEntities
{
	public interface IRoomTracking<TKey>
	{
		TKey? CreatedBy { get; set; }
		string? CreatedByName { get; set; }
		TKey? ModifiedBy { get; set; }
		string? ModifiedByName { get; set; }
	}
}
