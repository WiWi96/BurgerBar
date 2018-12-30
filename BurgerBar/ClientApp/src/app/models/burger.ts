import { Bun } from './bun';
import { Ingredient } from './ingredient';
import { Product } from './product';

export class Burger extends Product {
    code: string;
    bun: Bun;
    ingredients: Array<Ingredient> = [];
}
