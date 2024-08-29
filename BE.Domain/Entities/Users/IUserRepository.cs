using BE.Domain.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Users
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetAll();

        /// <summary>
        /// InsertUserRole
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        void InsertUserRole(Guid  userId, int roleId);
    }
}
