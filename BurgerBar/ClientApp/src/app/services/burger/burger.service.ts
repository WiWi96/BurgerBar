import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Burger } from '../../models/burger';
import { environment } from '../../../environments/environment';
import { BurgerDetails } from '../../models/burger-details';

@Injectable({
    providedIn: 'root'
})
export class BurgerService {
    private apiPath = environment.api + '/Burgers';

    constructor(private client: HttpClient) { }

    public getBurgers(): Observable<Burger[]> {
        return this.client.get<Burger[]>(this.apiPath);
    }

    public getBurgerDetails(id: number): Observable<BurgerDetails> {
        return this.client.get<BurgerDetails>(this.apiPath + '/' + id);
    }

    public postBurger(burger: BurgerDetails): Observable<Burger> {
        return this.client.post<Burger>(this.apiPath, burger);
    }

    public putBurger(id: number, burger: BurgerDetails): Observable<Burger> {
        return this.client.put<Burger>(this.apiPath + '/' + id, burger);
    }

    public deleteBurger(id: number): Observable<Burger> {
        return this.client.delete<Burger>(this.apiPath + '/' + id);
    }
}
