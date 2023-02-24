using Advanced_Ecommerce.Core.Entity.Concrete.Auth;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using Advanced_Ecommerce.Entities.Dtos.Category;
using Advanced_Ecommerce.Entities.Dtos.Color;
using Advanced_Ecommerce.Entities.Dtos.Model;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using Advanced_Ecommerce.Entities.Dtos.UserDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<User, UserDetailDto>();
            CreateMap<UserDetailDto, User>();


            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserAddDto>();
            CreateMap<UserAddDto, User>();

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();


            CreateMap<Brand, BrandDetailDto>();
            CreateMap<BrandDetailDto, Brand>();

            CreateMap<Brand, BrandAddDto>();
            CreateMap<BrandAddDto, Brand>();

            CreateMap<Brand, BrandUpdateDto>();
            CreateMap<BrandUpdateDto, Brand>();


            CreateMap<Product, ProductDetailDto>();
            CreateMap<ProductDetailDto, Product>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product,ProductDto>();

            CreateMap<Color, ColorAddDto>();
            CreateMap<ColorAddDto, Color>();

            CreateMap<Color, ColorDetailDto>();
            CreateMap<ColorDetailDto, Color>();

            CreateMap<Color, ColorDto>();
            CreateMap<ColorDto, Color>();


            CreateMap<ProductColor, ProductColorAddDto>();
            CreateMap<ProductColorAddDto, ProductColor>();

            CreateMap<ProductColor, ProductColorDto>();
            CreateMap<ProductColorDto, ProductColor>();

            CreateMap<Model, ModelAddDto>();
            CreateMap<ModelAddDto, Model>();

            CreateMap<Model,ModelDto>();
            CreateMap<ModelDto, Model>();

            CreateMap<Model, ModelDetailDto>();
            CreateMap<ModelDetailDto, Model>(); 

            CreateMap<Model,ModelUpdateDto>();
            CreateMap<ModelUpdateDto, Model>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();


            CreateMap<Category, CategoryAddDto>(); 
            CreateMap<CategoryAddDto, Category>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CategoryDetailDto, Category>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();


            CreateMap<SubCategory, SubCategoryAddDto>();
            CreateMap<SubCategoryAddDto, SubCategory>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, SubCategory>();

            CreateMap<SubCategory, SubCategoryDetailDto>();
            CreateMap<SubCategoryDetailDto, SubCategory>();

            CreateMap<SubCategory, SubCategoryUpdateDto>();
            CreateMap<SubCategoryUpdateDto, SubCategory>();

        }

    }
}
