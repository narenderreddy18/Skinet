using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ProductToReturnDTO>()
                .ForMember(d => d.productBrand, k => k.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.productType, k => k.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, k => k.MapFrom<ProductURLResolver>());
        }
    }
}
