﻿using Microsoft.AspNetCore.Identity;
using NETMVC_Upg1.Models;
using NETMVC_Upg1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCUpg1.Models;

namespace MVCUpg1.Services.Identity
{
    public interface IIdentityService
    {

        Task CreateRootAccountAsync();

        Task CreateNewRole(string roleName);

        Task<IdentityResult> CreateNewUserAsync(AppUser user, string password);

        Task AddUserToRole(AppUser user, string roleName);

        IEnumerable<AppUser> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();

        Task <IEnumerable<UserViewModel>> GetAllUsersWithRolesAsync();
    }
}
