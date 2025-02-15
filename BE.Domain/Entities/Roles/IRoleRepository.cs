﻿using BE.Domain.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Domain.Entities.Roles
{
    public interface IRoleRepository : IBaseRepository<Role, int>
    {
    }
}
