import { ProductType } from './product-type';

export class ProductDetails {
    id?: number;
    name: string;
    price: number;
    type: ProductType;
    isInMenu: boolean;
    active: boolean;
}
