import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-configurator',
    templateUrl: './configurator.component.html',
    styleUrls: ['./configurator.component.scss']
})
export class ConfiguratorComponent implements OnInit {

    code: string;
    wrongInput = false;

    constructor(private router: Router) { }

    ngOnInit() {
    }

    findConfiguration() {
        if (this.code && this.code.length <= 8) {
            this.router.navigateByUrl(`/configure/${this.code}`);
        } else {
            this.wrongInput = true;
        }
    }
}
