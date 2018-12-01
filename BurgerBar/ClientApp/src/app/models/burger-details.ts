import { ProductDetails } from './product-details';
import { BunDetails } from './bun-details';
import { IngredientDetails } from './ingredient-details';
import { CreationType } from './enums/creation-type';

export class BurgerDetails extends ProductDetails {
    code?: number;
    bun: BunDetails;
    ingredients: Array<IngredientDetails> = [];
    creationType?: CreationType;
}
