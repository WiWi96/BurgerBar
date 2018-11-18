import { Product } from "./product";
import { Bun } from "./bun";
import { Ingredient } from "./ingredient";
import { CreationType } from "./enums/creation-type";

export class Burger extends Product {
    number?: number;
    bun: Bun;
    ingredients: Array<Ingredient> = [];
    creationType: CreationType;
}
