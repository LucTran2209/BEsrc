using BE.Domain.Entities.Roles;
using BE.Domain.Entities.Users;
using BE.Infrastructure.Abstractions;
using BE.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BE.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public IQueryable<User> GetAll()
        {
            var query = context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(r => r.Role)
                .AsQueryable();
            return query;
        }

        public async void Insert(User entity)
        {
            await context.Users.AddAsync(entity);
        }

        public async void InsertUserRole(Guid userId, int roleId)
        {
            var userRole = new UserRoles
            {
                RoleId = roleId,
                UserId = userId,
            };
            await context.UserRoles.AddAsync(userRole);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
        }
    }
}
