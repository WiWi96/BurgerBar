import { IngredientType } from './ingredient-type';

export class Ingredient {
    id: number;
    name: string;
    price?: number;
    description: string;
    type: IngredientType;
    picture?: string;
}
