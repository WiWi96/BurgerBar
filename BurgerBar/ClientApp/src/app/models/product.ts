import { CreationType } from "./enums/creation-type";

export class Product {
  id?: number;
  name: string;
  price: number;
  isInMenu: boolean;
  creationType: CreationType;
}
