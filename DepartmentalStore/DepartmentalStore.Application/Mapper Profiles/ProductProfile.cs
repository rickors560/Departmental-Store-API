using AutoMapper;
using DepartmentalStore.Application.Features.Product.Commands.CreateProduct;
using DepartmentalStore.Application.Features.Product.Commands.UpdateProduct;
using DepartmentalStore.Application.Features.Product.Queries.GetProduct;
using DepartmentalStore.Application.Features.Product.Queries.GetProducts;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Price, GetProductsPriceDto>();
            this.CreateMap<Product, GetProductsVM>()
                .ForMember(vm => vm.Price, opt => {
                    opt.MapFrom(p => p.Prices
                            .Single(y => y.EffectiveDate == p.Prices
                                    .OrderBy(e => e.EffectiveDate).LastOrDefault().EffectiveDate));
                });
            this.CreateMap<Inventory, GetProductsInventoryDto>();

            this.CreateMap<Price, GetProductPriceDto>()
                .ForMember(vm => vm.PriceId, opt => opt.MapFrom(p => p.Id));
            this.CreateMap<Inventory, GetProductInventoryDto>();
            this.CreateMap<Product, GetProductVM>();

            this.CreateMap<Product, CreateProductVM>().ReverseMap();

            this.CreateMap<Product, UpdateProductVM>().ReverseMap();
        }
    }
}
