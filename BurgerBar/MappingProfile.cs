using AutoMapper;
using BurgerBar.Entities;
using BurgerBar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Burger, BurgerDTO>();
            CreateMap<BurgerDTO, Burger>();

            CreateMap<Bun, BunDTO>();
            CreateMap<BunDTO, Bun>();
        }
    }
}
