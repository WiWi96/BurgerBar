import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DeliveryType } from '../../models/delivery-type';

@Injectable({
  providedIn: 'root'
})
export class DeliveryTypeService {
    private apiPath = environment.api + '/DeliveryTypes';

    constructor(private client: HttpClient) { }

    public getDeliveryTypes(): Observable<DeliveryType[]> {
        return this.client.get<DeliveryType[]>(this.apiPath);
    }
}
