using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement
{
    public class PermissionsDto
    {
        public string Permission { get; set; } = string.Empty;

        private class PermissionMapping : Profile
        {
            public PermissionMapping()
            {
                CreateMap<Claim, PermissionsDto>()
                    .ForMember(dto => dto.Permission, obj => obj.MapFrom(src => src.Value));
            }
        }
    }
}
