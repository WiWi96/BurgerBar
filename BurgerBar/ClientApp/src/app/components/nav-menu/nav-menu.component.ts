import { Component, HostListener } from '@angular/core';
import { faHome, faUtensils, faQuestionCircle, faPhone, faConciergeBell, faStoreAlt, faCog, faShoppingCart, faKey, faSignInAlt, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { CartService } from '../../services/cart/cart.service';
import { AuthService } from '../../services/auth/auth.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
    isExpanded = false;
    innerWidth: number;
    cartCount = 0;

    faHome = faHome;
    faUtensils = faUtensils;
    faQuestionCircle = faQuestionCircle;
    faPhone = faPhone;
    faConciergeBell = faConciergeBell;
    faStoreAlt = faStoreAlt;
    faCog = faCog;
    faShoppingCart = faShoppingCart;
    faSignInAlt = faSignInAlt;
    faSignOutAlt = faSignOutAlt;

    constructor(private cartService: CartService,
        private authService: AuthService) {

    }

    ngOnInit() {
        this.innerWidth = window.innerWidth;
        this.cartService.cartCount.subscribe(
            data => this.cartCount = data);
    }

    @HostListener('window:resize', ['$event'])
    onResize(event) {
        this.innerWidth = window.innerWidth;
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    get auth() {
        return this.authService;
    }
}
