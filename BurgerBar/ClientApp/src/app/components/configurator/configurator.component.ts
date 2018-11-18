import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-configurator',
    templateUrl: './configurator.component.html',
    styleUrls: ['./configurator.component.scss']
})
export class ConfiguratorComponent implements OnInit {

    code: string;

    constructor(private router: Router) { }

    ngOnInit() {
    }

    findConfiguration() {
        this.router.navigateByUrl(`/configure/${this.code}`);
    }
}
