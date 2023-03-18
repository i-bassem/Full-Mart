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
            #region Product To ProductCategoryBrandDto And Reverse

            CreateMap<Product, ProductCategoryBrandDto>()


                .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.PName))
                .ForMember(dest => dest.ProductDescription,
                src => src.MapFrom(src => src.PDescription))
                .ForMember(dest => dest.CategoryName,
                src => src.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.Comment,
                src => src.MapFrom(src => src.Reviews.Select(r =>r.Comment).ToList()))
                .ForMember(dest => dest.BrandName,
                src => src.MapFrom(src => src.Brand.BrandName))


                .ReverseMap();


            CreateMap<Product, CartProductDTO>().ReverseMap();
  




            #endregion

            #region  Product  To NewProductDto and Reverse
            CreateMap<Product, NewProductDto>()
                //  .ForMember(dest => dest.Name,
                //src => src.MapFrom(src => src.PName))
                //.ForMember(dest => dest.Description,
                //src => src.MapFrom(src => src.PDescription))
                //.ForMember(dest => dest.CategoryId,
                //src => src.MapFrom(src => src.Category.Id))
                //.ForMember(dest => dest.BrandId,
                //src => src.MapFrom(src => src.Brand.Id))

               .ReverseMap();


            #endregion

            #region Review To ReviewProduct 


            CreateMap<Review, ReviewProductDto>()


            .ForMember(dest => dest.Comment,
                src => src.MapFrom(src => src.Comment))

            .ForMember(dest => dest.NumberOfStar,
                src => src.MapFrom(src => src.NumberOfStar))

            .ForMember(dest => dest.UserId,
                src => src.MapFrom(src => src.AppUser.UserName))
            .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.Product.PName))
            .ReverseMap();
            #endregion


            #region NewReview To Review

            CreateMap<Review, NewReviewDto>()


            //.ForMember(dest => dest.Comment,
            //    src => src.MapFrom(src => src.Comment))

            //.ForMember(dest => dest.NumberOfStar,
            //    src => src.MapFrom(src => src.NumberOfStar))

            //.ForMember(dest => dest.AppUserId,
            //    src => src.MapFrom(src => src.AppUser.Id))
            //.ForMember(dest => dest.ProductId,
            //    src => src.MapFrom(src => src.Product.Id))
                .ReverseMap();
            #endregion

            #region  WishListProduct To  WishListProductUserDTO and Reverse



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


            #region order maping
    

            CreateMap<Order, OrderDTO>()
        .ForMember(dest => dest.ProductNames,
               src => src.MapFrom(src => src.OrderProducts.
               Select(a => a.Product.PName).ToList()));

            CreateMap<OrderProductCreateDTO, OrderProduct>()
      .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))

      .ForMember(dest => dest.Order, opt => opt.Ignore()).ReverseMap();

            CreateMap<OrderCreateDTO, Order>()
                .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();

            #endregion

            #region brand
            CreateMap<BrandDTO, Brand>()
     .ForMember(dest => dest.Id, opt => opt.Ignore())
     .ForMember(dest => dest.Products, opt => opt.ToString())
     .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName)).ReverseMap();


            // CreateMap<Brand, BrandDTO>()

            //.ForMember(dest => dest.ProductNames, opt => opt.MapFrom(src => src.Products.Select(p => p.PName).ToList()));


            #endregion




        }
    }
}
