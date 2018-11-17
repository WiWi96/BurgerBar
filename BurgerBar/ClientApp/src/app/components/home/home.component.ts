import { Component, OnInit } from '@angular/core';
import { BurgerService } from '../../services/burger/burger.service';
import { Burger } from '../../models/burger';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

    burgers: Burger[];

    constructor(private service: BurgerService) { }

    ngOnInit() {
        this.getBurgers();
    }

    getBurgers() {
        this.service.getBurgers().subscribe(data => this.burgers = data);
    }
}
