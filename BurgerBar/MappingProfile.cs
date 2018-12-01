using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BurgerBar.Entities;
using BurgerBar.ViewModels;

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

            CreateMap<Burger, BurgerDTO>()
                .ForMember(o => o.Ingredients, m => m.MapFrom(obj => ConvertToIngredient(obj.Ingredients)));
            CreateMap<BurgerDTO, Burger>();

            CreateMap<Burger, AddBurgerDTO>();
            CreateMap<AddBurgerDTO, Burger>()
                .ForMember(o => o.Bun, m => m.MapFrom(dto => new Bun { Id = dto.BunId }))
                .ForMember(o => o.Ingredients, m => m.MapFrom(dto => CreateBurgerIngredient(dto.IngredientIds)));

            CreateMap<Bun, BunDTO>();
            CreateMap<BunDTO, Bun>();
        }

        private static IEnumerable<Ingredient> ConvertToIngredient(IEnumerable<BurgerIngredient> burgerIngredients)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            burgerIngredients = (burgerIngredients as List<BurgerIngredient>).OrderBy(o => o.Position).AsEnumerable();

            foreach (BurgerIngredient bi in burgerIngredients)
            {
                ingredients.Add(bi.Ingredient);
            }

            return ingredients;
        }

        private static IEnumerable<BurgerIngredient> CreateBurgerIngredient(IEnumerable<long> ingredientIds)
        {
            List<BurgerIngredient> burgerIngredients = new List<BurgerIngredient>();

            short i = 0;
            foreach (long id in ingredientIds)
            {
                burgerIngredients.Add(new BurgerIngredient
                {
                    Ingredient = new Ingredient
                    {
                        Id = id
                    },
                    Position = i
                });
                i++;
            }

            return burgerIngredients;
        }
    }
}
