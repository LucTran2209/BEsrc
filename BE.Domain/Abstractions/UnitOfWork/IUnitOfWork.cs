using BE.Domain.Entities.Roles;
using BE.Domain.Entities.Rooms;
﻿using BE.Domain.Entities.Building;
using BE.Domain.Entities.Users;

namespace BE.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IBuildingRepository BuildingRepository { get; }

        public IRoomRepository RoomRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        void RollBack();
    }
}
