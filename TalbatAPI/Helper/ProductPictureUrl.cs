using AutoMapper;
using AutoMapper.Execution;
using Microsoft.IdentityModel.Tokens;
using TalbatAPI.Dtos;
using TalbatCore.Entites;

namespace TalbatAPI.Helper
{
    public class ProductPictureUrl : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return $"{configuration["apiBaseUrl"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
