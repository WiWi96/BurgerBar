import { CreationType } from "./enums/creation-type";
import { ProductType } from "./product-type";

export class Product {
    id?: number;
    name: string;
    price: number;
    type: ProductType;
    isInMenu: boolean;
    creationType: CreationType;
}
