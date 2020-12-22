﻿using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Models;
using Tennis.DTO.Read;

namespace Tennis.BLL.Interface
{
    public interface IRoleService : IGenericService<Role, int, RoleReadDTO>
    {

    }
}
