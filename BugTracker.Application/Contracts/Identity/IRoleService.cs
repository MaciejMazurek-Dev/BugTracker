﻿using BugTracker.Application.Models.Identity;

namespace BugTracker.Application.Contracts.Identity
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRoles(string userId);
        Task<List<RoleModel>> GetAllRoles();
    }
}
