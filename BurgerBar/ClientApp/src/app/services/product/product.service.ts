import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OtherProduct } from '../../models/other-product';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ProductType } from '../../models/product-type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    private apiPath = environment.api + '/Products';

    constructor(private client: HttpClient) { }

    public getProducts(): Observable<OtherProduct[]> {
        return this.client.get<OtherProduct[]>(this.apiPath);
    }

    public getMenuProducts(): Observable<OtherProduct[]> {
        return this.client.get<OtherProduct[]>(`${this.apiPath}/menu`);
    }

    public getOtherProduct(id: number): Observable<OtherProduct> {
        return this.client.get<OtherProduct>(this.apiPath + '/' + id);
    }

    public postProduct(product: OtherProduct): Observable<OtherProduct> {
        return this.client.post<OtherProduct>(this.apiPath, product);
    }

    public putProduct(id: number, product: OtherProduct): Observable<OtherProduct> {
        return this.client.put<OtherProduct>(this.apiPath + '/' + id, product);
    }

    public deleteProduct(id: number): Observable<OtherProduct> {
        return this.client.delete<OtherProduct>(this.apiPath + '/' + id);
    }

    public getProductTypes(): Observable<ProductType[]> {
        return this.client.get<ProductType[]>(this.apiPath + '/types');
    }
}
