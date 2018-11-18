import { ProductType } from "./product-type";

export class Product {
    id?: number;
    name: string;
    price: number;
    type: ProductType;
    isInMenu: boolean;
}
