import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-configurator-viewer',
    templateUrl: './configurator-viewer.component.html',
    styleUrls: ['./configurator-viewer.component.scss']
})
export class ConfiguratorViewerComponent implements OnInit {
    code: string;

    constructor(private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);
    }

}
