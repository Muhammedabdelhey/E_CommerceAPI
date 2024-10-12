﻿using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.RoleManagement.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, IdentityRole>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityRole> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id)
            ?? throw new ValidationException($"Role with Guid {request.Id} not Exist");
            await _roleManager.DeleteAsync(role);
            return role;
        }
    }
}