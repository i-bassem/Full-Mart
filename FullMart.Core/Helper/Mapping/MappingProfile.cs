using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Helper.AutoMapper
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            //Source => My Domain Model
            //Destination => MY DTO
            CreateMap<Product, ProductCategoryBrandDto>()


                //.ForMember(dest => dest.ProductName,
                //src => src.MapFrom(src => src.PName))
                //.ForMember(dest => dest.ProductDescription,
                //src => src.MapFrom(src => src.PDescription))
                //.ForMember(dest => dest.CategoryName,
                //src => src.MapFrom(src => src.Category.CategoryName))
                //.ForMember(dest => dest.BrandId,
                //src => src.MapFrom(src => src.Brand.Id))
                //.ForMember(dest => dest.IsFree,
                //src => src.MapFrom(src => src.Price == 0))
               
                .ReverseMap();

            CreateMap<Product, NewProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();



            //CreateMap<TableA, TableAViewModel>();
            //CreateMap<TableB, TableBViewModel>();
            //CreateMap<MappingTable, MappingTableViewModel>();

            //CreateMap<AppUser, WishListProductUserDTO>()
            //    .ForMember(dest => dest.UserName ,
            //    src => src.MapFrom(src => src.FirstName))
            //    .ReverseMap();

            CreateMap<WishListProduct, WishListProductUserDTO>()

                .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.Product.PName.ToList()))
                .ReverseMap();

            //CreateMap<Product, WishListProduct>();
            //CreateMap<WishListProduct, WishListProductUserDTO>()

            //.ForMember(dest => dest.UserName,
            //src => src.MapFrom(src => src.AppUser.UserName))

            //.ForMember(dest => dest.ProductName,
            //src => src.MapFrom(src => src.Product.PName))

            //.ForMember(dest => dest.ProductDescription,
            //src => src.MapFrom(src => src.WishListProducts))

            //.ForMember(dest => dest.Price,
            //src => src.MapFrom(src => src.WishListProducts))

            //.ForMember(dest => dest.ImageUrl,
            //src => src.MapFrom(src => src.WishListProducts))

            //.ForMember(dest => dest.Quantity,
            //src => src.MapFrom(src => src.WishListProducts))

            //.ForMember(dest => dest.Rate,
            //src => src.MapFrom(src => src.WishListProducts))

            //.ReverseMap();

            //  CreateMap<WishList, WishListProductUserDTO>()


            //.ForMember(dest => dest.UserName,
            //src => src.MapFrom(src => src.AppUser.UserName))

            //.ForMember(dest => dest.ProductName,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.PName).ToList()))

            //.ForMember(dest => dest.ProductDescription,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.PDescription)))

            //.ForMember(dest => dest.Price,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.Price)))

            //.ForMember(dest => dest.Quantity,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.Quantity)))

            //.ForMember(dest => dest.ImageUrl,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.ImageUrl)))

            //.ForMember(dest => dest.Rate,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.Rate)))

            //.ForMember(dest => dest.ImageUrl,
            //src => src.MapFrom(src => src.WishListProduct.Products.Select(p => p.ImageUrl)))

            //.ReverseMap();

        }
    }
}
