import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Bun } from '../../models/bun';
import { environment } from '../../../environments/environment';
import { BunDetails } from '../../models/bun-details';

@Injectable({
  providedIn: 'root'
})
export class BunService {
    private apiPath = environment.api + '/Buns';

    constructor(private client: HttpClient) { }

    public getBuns(): Observable<Bun[]> {
        return this.client.get<Bun[]>(this.apiPath);
    }

    public getAvailableBuns(): Observable<Bun[]> {
        return this.client.get<Bun[]>(`${this.apiPath}/available`);
    }

    public getBunDetails(id: number): Observable<BunDetails> {
        return this.client.get<BunDetails>(this.apiPath + '/' + id);
    }

    public postBun(bun: BunDetails): Observable<Bun> {
        return this.client.post<Bun>(this.apiPath, bun);
    }

    public putBun(id: number, bun: BunDetails): Observable<Bun> {
        return this.client.put<Bun>(this.apiPath + '/' + id, bun);
    }

    public deleteBun(id: number): Observable<Bun> {
        return this.client.delete<Bun>(this.apiPath + '/' + id);
    }
}
