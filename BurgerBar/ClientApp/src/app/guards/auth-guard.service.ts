import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private jwtHelper: JwtHelper, private router: Router) {
    }

    canActivate() {
        var token = localStorage.getItem("jwt");

        if (token && !this.jwtHelper.isTokenExpired(token)) {
            return true;
        }
        this.router.navigate(["login"]);
        return false;
    }
}
