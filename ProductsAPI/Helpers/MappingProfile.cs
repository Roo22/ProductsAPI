using AutoMapper;

namespace ProductsAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
          CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(src => src.Image, opt => opt.Ignore());
        }
    }
}
