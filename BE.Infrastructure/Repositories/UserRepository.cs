using BE.Domain.Entities.Users;
using BE.Infrastructure.Abstractions;
using BE.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async void Insert(User entity)
        {
            await context.Users.AddAsync(entity);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
        }
    }
}
