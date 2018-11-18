import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../models/product';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ProductType } from '../../models/product-type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    private apiPath = environment.api + '/Products';

    constructor(private client: HttpClient) { }

    public getProducts(): Observable<Product[]> {
        return this.client.get<Product[]>(this.apiPath);
    }

    public getProduct(id: number): Observable<Product> {
        return this.client.get<Product>(this.apiPath + '/' + id);
    }

    public postProduct(product: Product): Observable<Product> {
        return this.client.post<Product>(this.apiPath, product);
    }

    public putProduct(id: number, product: Product): Observable<Product> {
        return this.client.put<Product>(this.apiPath + '/' + id, product);
    }

    public deleteProduct(id: number): Observable<Product> {
        return this.client.delete<Product>(this.apiPath + '/' + id);
    }

    public getProductTypes(): Observable<ProductType[]> {
        return this.client.get<ProductType[]>(this.apiPath + '/types');
    }
}
