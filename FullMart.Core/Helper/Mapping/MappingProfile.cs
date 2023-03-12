using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
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
                .ForMember(dest => dest.BrandId,
                src => src.MapFrom(src => src.Brand.Id))


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




            CreateMap<WishListProduct, WishListProductUserDTO>()

                .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.Product.PName))

                .ForMember(dest => dest.ProductDescription,
                src => src.MapFrom(src => src.Product.PDescription))

                .ForMember(dest => dest.Price,
                src => src.MapFrom(src => src.Product.Price))

                .ForMember(dest => dest.ImageUrl,
                src => src.MapFrom(src => src.Product.ImageUrl))

                .ForMember(dest => dest.Quantity,
                src => src.MapFrom(src => src.Product.Quantity))

                .ForMember(dest => dest.Rate,
                src => src.MapFrom(src => src.Product.Rate))

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
