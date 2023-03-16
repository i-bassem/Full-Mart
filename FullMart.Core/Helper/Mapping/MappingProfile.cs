using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.Models.JwtModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FullMart.Core.DTOS.ProductsInCategoryDto;

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


            #region Mapping wishList Product

            CreateMap<Product, WishListProductUserDTO>()

                .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.PName))

                .ForMember(dest => dest.ProductDescription,
                src => src.MapFrom(src => src.PDescription))

                .ForMember(dest => dest.Price,
                src => src.MapFrom(src => src.Price))

                .ForMember(dest => dest.ImageUrl,
                src => src.MapFrom(src => src.ImageUrl))

                .ForMember(dest => dest.Quantity,
                src => src.MapFrom(src => src.Quantity))

                .ForMember(dest => dest.Rate,
                src => src.MapFrom(src => src.Rate))

                .ReverseMap();

            #endregion

            #region Mapping AppUser RegisterModel

            CreateMap<AppUser, RegisterModel>()
                .ForMember(dest => dest.Username, src => src.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(src => src.ImageUrl))
                .ReverseMap();

            #endregion

            #region Categories

            CreateMap<Category, ProductsInCategoryDto>()
                .ForMember(dsc => dsc.categoryID, src => src.MapFrom(src => src.Id))
                .ForMember(dsc => dsc.categoryName, src => src.MapFrom(src => src.CategoryName))
                .ForMember(dsc => dsc.categoryImageURL, src => src.MapFrom(src => src.ImageUrl))
                .ReverseMap();

            CreateMap<Category, NewCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ForMember(dsc => dsc.productID, src => src.MapFrom(src => src.Id))
                .ForMember(dsc => dsc.productName, src => src.MapFrom(src => src.PName))
                .ForMember(dsc => dsc.productPrice, src => src.MapFrom(src => src.Price))
                .ForMember(dsc => dsc.productImageURL, src => src.MapFrom(src => src.ImageUrl))
                .ForMember(dsc => dsc.productRating, src => src.MapFrom(src => src.Rate))
                .ReverseMap(); 

            #endregion






        }
    }
}
