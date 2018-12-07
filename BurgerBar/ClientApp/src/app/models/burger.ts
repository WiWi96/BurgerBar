import { Bun } from './bun';
import { Ingredient } from './ingredient';
import { Product } from './product';

export class Burger {
    id?: number;
    name: string;
    price: number;
    code: string;
    bun: Bun;
    ingredients: Array<Ingredient> = [];
}
