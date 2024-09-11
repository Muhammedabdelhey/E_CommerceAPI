namespace E_Commerce.Application.Brands.Queries.GetBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBaseRepository<Brand> _brandRepository;

        public GetBrandsQueryHandler(IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync(cancellationToken);
            return brands;
        }
    }
}
