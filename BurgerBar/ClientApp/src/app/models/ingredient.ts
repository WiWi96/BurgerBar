import { IngredientType } from './ingredient-type';
import { File } from './file';

export class Ingredient {
    id: number;
    name: string;
    price?: number;
    description: string;
    type: IngredientType;
    picture?: File;
}
