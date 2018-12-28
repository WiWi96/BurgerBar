import { IngredientType } from './ingredient-type';
import { File } from './file';

export class IngredientDetails {
    id?: number;
    name: string;
    description?: string;
    type: IngredientType;
    price?: number;
    picture?: File;
    active: boolean;
}
