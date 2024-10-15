using E_Commerce.Domain.Comman;

namespace E_Commerce.Application.Common.Validator
{
    public class EntityExistenceValidator<TEntity> : AbstractValidator<string?> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        public EntityExistenceValidator(IBaseRepository<TEntity> repository)
        {
            _repository = repository;

            RuleFor(id => id)
                .MustAsync(ExistInDatabase)
                .WithMessage(id=> $"The {typeof(TEntity).Name} With ID: {id} Doesn't Exist In Database.");
        }
        private async Task<bool> ExistInDatabase(string? id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            return await _repository.GetByIdAsync(Guid.Parse(id), cancellationToken) is not null;
        }
    }
}