import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaymentType } from '../../models/payment-type';

@Injectable({
    providedIn: 'root'
})
export class PaymentTypeService {
    private apiPath = environment.api + '/PaymentTypes';

    constructor(private client: HttpClient) { }

    public getPaymentTypes(): Observable<PaymentType[]> {
        return this.client.get<PaymentType[]>(this.apiPath);
    }
}
