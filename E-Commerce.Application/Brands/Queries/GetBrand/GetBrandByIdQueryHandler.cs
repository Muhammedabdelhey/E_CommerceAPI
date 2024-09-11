
using E_Commerce.Application.Common.Exceptions;

namespace E_Commerce.Application.Brands.Queries
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public GetBrandByIdQueryHandler(IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
            if (brand == null)
            {
                throw new NotFoundException($"Brand with ID {request.Id} not found.");
            }
            return brand;
        }
    }
}
