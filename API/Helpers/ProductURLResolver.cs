using API.DTO;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductURLResolver : IValueResolver<Products, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductURLResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Products source, ProductToReturnDTO destination,
            string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiURL"] + source.PictureUrl;
            }
            return null;
        }
    }
}
