using BE.Domain.Entities.Roles;
using BE.Infrastructure.Abstractions;
using BE.Persistence;

namespace BE.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
