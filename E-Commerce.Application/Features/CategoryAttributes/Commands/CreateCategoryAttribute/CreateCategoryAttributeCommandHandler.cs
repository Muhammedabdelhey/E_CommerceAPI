using System.ComponentModel;

namespace E_Commerce.Application.Features.CategoryAttributes.Commands.CreateCategoryAttribute
{
    public class CreateCategoryAttributeCommandHandler : IRequestHandler<CreateCategoryAttributeCommand, CategoryAttribute>
    {
        private readonly IBaseRepository<CategoryAttribute> _repository;
        public CreateCategoryAttributeCommandHandler(IBaseRepository<CategoryAttribute> repository)
        {
            _repository = repository;
        }
        public Task<CategoryAttribute> Handle(CreateCategoryAttributeCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
