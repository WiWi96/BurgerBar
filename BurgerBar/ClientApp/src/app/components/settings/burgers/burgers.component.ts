import { Component, OnInit } from '@angular/core';
import { faAngleDown, faWrench } from '@fortawesome/free-solid-svg-icons';
import { Burger } from '../../../models/burger';
import { BurgerService } from '../../../services/burger/burger.service';

@Component({
  selector: 'app-burgers',
  templateUrl: './burgers.component.html',
  styleUrls: ['./burgers.component.scss']
})
export class BurgersComponent implements OnInit {
    burgers: Burger[];
    faWrench = faWrench;
    faAngleDown = faAngleDown;

    constructor(private service: BurgerService) { }

    ngOnInit() {
        this.getBurgers();
    }

    getBurgers() {
        this.service.getBurgers().subscribe(data => this.burgers = data);
    }
}
