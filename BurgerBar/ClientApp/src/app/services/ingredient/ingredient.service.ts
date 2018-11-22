import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Ingredient } from '../../models/ingredient';
import { IngredientType } from '../../models/ingredient-type';
import { IngredientDetails } from '../../models/ingredient-details';

@Injectable({
    providedIn: 'root'
})
export class IngredientService {

    private apiPath = environment.api + '/Ingredients';

    constructor(private client: HttpClient) { }

    public getIngredients(): Observable<Ingredient[]> {
        return this.client.get<Ingredient[]>(this.apiPath);
    }

    public getIngredientDetails(id: number): Observable<IngredientDetails> {
        return this.client.get<IngredientDetails>(this.apiPath + '/' + id);
    }

    public postIngredient(ingredient: IngredientDetails): Observable<Ingredient> {
        return this.client.post<Ingredient>(this.apiPath, ingredient);
    }

    public putIngredient(id: number, ingredient: IngredientDetails): Observable<Ingredient> {
        return this.client.put<Ingredient>(this.apiPath + '/' + id, ingredient);
    }

    public deleteIngredient(id: number): Observable<Ingredient> {
        return this.client.delete<Ingredient>(this.apiPath + '/' + id);
    }

    public getIngredientTypes(): Observable<IngredientType[]> {
        return this.client.get<IngredientType[]>(this.apiPath + '/types');
    }
}
