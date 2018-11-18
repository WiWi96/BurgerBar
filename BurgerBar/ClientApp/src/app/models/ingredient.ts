import { IngredientType } from "./ingredient-type";

export class Ingredient {
    id?: number;
    name: string;
    description?: string;
    type: IngredientType;
    price?: number;
    picture?: string;
}
