import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BurgerDetails } from '../../../models/burger-details';
import { BurgerService } from '../../../services/burger/burger.service';

@Component({
    selector: 'app-configurator-viewer',
    templateUrl: './configurator-viewer.component.html',
    styleUrls: ['./configurator-viewer.component.scss']
})
export class ConfiguratorViewerComponent implements OnInit {
    burger: BurgerDetails;
    code: string;

    constructor(private activatedRoute: ActivatedRoute,
        private service: BurgerService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);


    }

}
