import { Component, OnInit } from '@angular/core';
import { faAngleDown, faWrench, faTimesCircle } from '@fortawesome/free-solid-svg-icons';
import { faCheckCircle } from '@fortawesome/free-regular-svg-icons';
import { BurgerService } from '../../../services/burger/burger.service';
import { Burger } from '../../../models/burger';

@Component({
  selector: 'app-burgers',
  templateUrl: './burgers.component.html',
  styleUrls: ['./burgers.component.scss']
})
export class BurgersComponent implements OnInit {
    burgers: Burger[];
    faWrench = faWrench;
    faAngleDown = faAngleDown;
    faCheckCircle = faCheckCircle;
    faTimesCircle = faTimesCircle;

    constructor(private service: BurgerService) { }

    ngOnInit() {
        this.getBurgers();
    }

    getBurgers() {
        this.service.getBurgers().subscribe(data => this.burgers = data);
    }
}
