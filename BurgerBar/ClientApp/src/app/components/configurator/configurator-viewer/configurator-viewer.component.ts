import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BurgerService } from '../../../services/burger/burger.service';
import { Burger } from '../../../models/burger';
import { faAngleDown } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'app-configurator-viewer',
    templateUrl: './configurator-viewer.component.html',
    styleUrls: ['./configurator-viewer.component.scss']
})
export class ConfiguratorViewerComponent implements OnInit {
    burger: Burger;
    code: string;

    showDetails = false;

    faAngleDown = faAngleDown;

    constructor(private activatedRoute: ActivatedRoute,
        private service: BurgerService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);

        if (this.code) {
            this.service.getBurgerByCode(this.code).subscribe(
                data => this.burger = data);
        }
    }

    expandDetails() {
        this.showDetails = true;
    }
}
