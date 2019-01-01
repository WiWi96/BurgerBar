import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

    bunsLoaded = false;
    burgersLoaded = false;
    ingredientsLoaded = false;
    productsLoaded = false;
    ordersLoaded = false;

    constructor() { }

    ngOnInit() {
        this.bunsLoaded = true;
    }

}
