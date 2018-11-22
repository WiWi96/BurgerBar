import { Component, OnInit } from '@angular/core';
import { BunDetails } from '../../../models/bun-details';
import { BsModalRef } from 'ngx-bootstrap';
import { BunService } from '../../../services/bun/bun.service';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-bun-modal',
    templateUrl: './bun-modal.component.html',
    styleUrls: ['./bun-modal.component.scss']
})
export class BunModalComponent implements OnInit {
    public onClose: Subject<BunDetails>;

    id: any;
    bun: BunDetails = new BunDetails();

    constructor(public bsModalRef: BsModalRef,
        private bunsService: BunService) { }

    ngOnInit() {
        this.onClose = new Subject();
        if (typeof (this.id) === 'number') {
            this.bunsService.getBunDetails(this.id).subscribe(data => this.bun = data);
        }
    }

    saveBun() {
        if (typeof (this.id) === 'number') {
            this.bunsService.putBun(this.id, this.bun).subscribe(data => this.onSuccess(data));
        } else {
            this.bunsService.postBun(this.bun).subscribe(data => this.onSuccess(data));
        }
    }

    onSuccess(data) {
        this.onClose.next(data);
        this.bsModalRef.hide();
    }
}
