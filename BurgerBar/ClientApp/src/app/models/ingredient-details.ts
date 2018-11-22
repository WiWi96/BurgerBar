import { IngredientType } from './ingredient-type';

export class IngredientDetails {
    id?: number;
    name: string;
    description?: string;
    type: IngredientType;
    price?: number;
    picture?: string;
    active: boolean;
}
