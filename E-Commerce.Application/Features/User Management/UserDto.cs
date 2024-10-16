namespace E_Commerce.Application.Features.User_Management
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string Address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public bool phoneNumberConfirmed { get; set; }

        private class UserMapping : Profile
        {
            public UserMapping() {
                CreateMap<User,UserDto>();
            }
        }
    }
}
