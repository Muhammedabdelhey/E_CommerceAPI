namespace E_Commerce.Application.Common.Validator
{
    public class EntityExistenceValidator<TEntity> : AbstractValidator<Guid> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        public EntityExistenceValidator(IBaseRepository<TEntity> repository)
        {
            _repository = repository;

            RuleFor(ids => ids)
                .MustAsync(ExistInDatabase)
                .WithMessage($"The {typeof(TEntity).Name} doesn't exist in the database.");
        }
        private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken) is not null;
        }
    }
}