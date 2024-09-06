
using E_Commerce.Domain.Interfcases;

namespace E_Commerce.Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;

        public CreateBrandCommandHandler(IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new Brand {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            await _brandRepository.AddAsync(brand,cancellationToken);
            return  brand;
        }
    }
}
