using AutoMapper;
using BurgerBar.Entities;
using BurgerBar.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BurgerBar
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();

            CreateMap<OtherProduct, OtherProductDTO>();
            CreateMap<OtherProductDTO, OtherProduct>();

            CreateMap<Burger, BurgerDTO>()
                .ForMember(o => o.Ingredients, m => m.MapFrom(obj => ConvertToIngredient(obj.Ingredients)));
            CreateMap<BurgerDTO, Burger>();

            CreateMap<Burger, AddBurgerDTO>();
            CreateMap<AddBurgerDTO, Burger>()
                .ForMember(o => o.Bun, m => m.MapFrom(dto => new Bun { Id = dto.BunId }))
                .ForMember(o => o.Ingredients, m => m.MapFrom(dto => CreateBurgerIngredient(dto.IngredientIds)));

            CreateMap<Bun, BunDTO>();
            CreateMap<BunDTO, Bun>();

            CreateMap<AddOrderDTO, Order>()
                .ForMember(o => o.PaymentType, m => m.MapFrom(dto => new PaymentType { Id = dto.PaymentTypeId }))
                .ForMember(o => o.DeliveryType, m => m.MapFrom(dto => new DeliveryType { Id = dto.DeliveryTypeId }));
            CreateMap<Order, OrderDTO>()
                .ForMember(o => o.CustomerFirstName, m => m.MapFrom(obj => obj.Customer.FirstName))
                .ForMember(o => o.CustomerLastName, m => m.MapFrom(obj => obj.Customer.LastName))
                .ForMember(o => o.ProductsCount, m => m.MapFrom(obj => obj.Products.Count));

            CreateMap<OrderedProductDTO, OrderedProduct>()
                .ForMember(o => o.Product, m => m.MapFrom(dto => new Product { Id = dto.ProductId }));
        }

        private static IEnumerable<Ingredient> ConvertToIngredient(IEnumerable<BurgerIngredient> burgerIngredients)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            burgerIngredients = burgerIngredients.OrderBy(o => o.Position);

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
