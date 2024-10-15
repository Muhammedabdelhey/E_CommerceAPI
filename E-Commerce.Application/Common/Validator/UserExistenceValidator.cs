using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Common.Validator
{
    public class UserExistenceValidator : AbstractValidator<string>
    {
        private readonly UserManager<User> _userManager;
        public UserExistenceValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(userId => userId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .MustAsync(UserExists)
                .WithMessage(userId => $"User With ID: {userId} Not Exist");
        }
        private async Task<bool> UserExists(string userId, CancellationToken cancellationToken)
        {
            return await _userManager.FindByIdAsync(userId) is not null;
        }
    }
}
