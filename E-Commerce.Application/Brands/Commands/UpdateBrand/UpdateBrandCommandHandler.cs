namespace E_Commerce.Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;

        public UpdateBrandCommandHandler(IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id));
            if (brand == null)
            {
                throw new NotFoundException($"Brand with ID {request.Id} not found.");
            }
            brand.Name = request.Name;
            await _brandRepository.UpdateAsync(brand);
            return brand;
        }
    }
}
