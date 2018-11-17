import { Product } from "./product";
import { Bun } from "./bun";
import { Ingredient } from "./ingredient";

export class Burger extends Product {
    number?: number;
    bun: Bun;
    ingredients: Array<Ingredient> = [];
}
