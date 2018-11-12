import { IngredientType } from "./enums/ingredient-type";

export class Burger {
  id?: number;
  name: string;
  description?: string;
  type: IngredientType;
  picture?: string;
}
