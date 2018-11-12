import { IngredientType } from "./enums/ingredient-type";

export class Ingredient {
  id?: number;
  name: string;
  description?: string;
  type: IngredientType;
  picture?: string;
}
