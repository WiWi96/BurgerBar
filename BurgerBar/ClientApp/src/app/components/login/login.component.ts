import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { NgForm } from '@angular/forms';
import { UserCredentials } from '../../models/user-credentials';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    invalidLogin: any;

    constructor(private authService: AuthService,
        private router: Router) { }

    ngOnInit() {
    }

    login(form: NgForm) {
        const credentials: UserCredentials = form.value;
        this.authService
            .login(credentials)
            .subscribe(data => {
                const token = (<any>data).token;
                localStorage.setItem('jwt', token);
                this.invalidLogin = false;
                this.router.navigate(['/']);
            }, _ => {
                this.invalidLogin = true;
            });
    }
}
