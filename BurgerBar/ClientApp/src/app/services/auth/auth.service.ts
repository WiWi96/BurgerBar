import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { UserCredentials } from '../../models/user-credentials';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    private apiPath = environment.api + '/Auth';

    constructor(private client: HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }

    login(credentials: UserCredentials): Observable<any> {
        return this.client.post(`${this.apiPath}/login`, credentials);
    }

    logOut() {
        localStorage.removeItem('jwt');
        this.router.navigate(['/']);
    }

    isLoggedIn(): boolean {
        const token = localStorage.getItem('jwt');
        return token != null && !this.jwtHelper.isTokenExpired(token);
    }
}
