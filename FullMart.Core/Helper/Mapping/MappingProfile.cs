﻿using AutoMapper;
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


                .ForMember(dest => dest.ProductName,
                src => src.MapFrom(src => src.PName))
                .ForMember(dest => dest.ProductDescription,
                src => src.MapFrom(src => src.PDescription))
                .ForMember(dest => dest.CategoryName,
                src => src.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.BrandName,
                src => src.MapFrom(src => src.Brand.BrandName))
                .ForMember(dest => dest.IsFree,
                src => src.MapFrom(src => src.Price == 0))
               
                .ReverseMap();

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


        }
    }
}
