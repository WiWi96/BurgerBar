import { Address } from "./address";

export class Customer {
  id?: number;
  firstName: string;
  lastName: string;
  address: Address;
  phoneNumber?: string;
  email?: string;
}
