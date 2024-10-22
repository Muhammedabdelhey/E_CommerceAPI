using E_Commerce.Domain.Interfcases;

namespace E_Commerce.Application.Common.Resolvers
{
    internal class ImageResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string?>
        where TSource : class, IEntityHasImage
    {
        private readonly IFileService _fileService;

        public ImageResolver(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string? Resolve(TSource? source, TDestination destination, string? destMember, ResolutionContext context)
        {
            if (source == null || string.IsNullOrEmpty(source.Image))
            {
                return null;
            }

            return _fileService.GetFileUrl(source.Image);
        }
    }
}
