using AutoMapper;
using TalbatAPI.Dtos;
using TalbatAPI.Helper;
using TalbatCore.Entites;

namespace TalbatAPI.Mapping
{
    public class TalbatMapping : Profile
    {
        public TalbatMapping()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrl>());
                
        }
    }
}
