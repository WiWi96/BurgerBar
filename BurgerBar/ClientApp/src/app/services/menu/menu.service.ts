import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Burger } from '../../models/burger';
import { OtherProduct } from '../../models/other-product';

@Injectable({
    providedIn: 'root'
})
export class MenuService {
    private apiPath = environment.api + '/Menu';

    constructor(private client: HttpClient) { }

    public getBurgers(): Observable<Burger[]> {
        return this.client.get<Burger[]>(`${this.apiPath}/burger`);
    }

    public getProducts(): Observable<OtherProduct[]> {
        return this.client.get<OtherProduct[]>(`${this.apiPath}/other-product`);
    }

    public addToMenu(id: number): Observable<boolean> {
        return this.client.post<boolean>(`${this.apiPath}/product`, id);
    }

    public deleteFromMenu(id: number): Observable<boolean> {
        return this.client.delete<boolean>(`${this.apiPath}/product/${id}`);
    }
}
