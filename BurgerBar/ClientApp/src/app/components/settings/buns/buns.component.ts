import { Component, OnInit } from '@angular/core';
import { BunService } from '../../../services/bun/bun.service';
import { faAngleDown, faWrench } from '@fortawesome/free-solid-svg-icons';
import { BunModalComponent } from '../../modals/bun-modal/bun-modal.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Bun } from '../../../models/bun';

@Component({
    selector: 'app-buns',
    templateUrl: './buns.component.html',
    styleUrls: ['./buns.component.scss']
})
export class BunsComponent implements OnInit {

    buns: Bun[];
    faWrench = faWrench;
    faAngleDown = faAngleDown;
    bsModalRef: BsModalRef;

    constructor(private service: BunService,
        private modalService: BsModalService) { }

    ngOnInit() {
        this.getBuns();
    }

    getBuns() {
        this.service.getBuns().subscribe(data => this.buns = data);
    }

    addBun() {
        this.openBunModal();
    }

    editBun(id: number) {
        this.openBunModal(id);
    }

    openBunModal(id?: any) {
        const initialState = {
            id
        };
        this.bsModalRef = this.modalService.show(BunModalComponent, { initialState });
        this.bsModalRef.content.onClose.subscribe(result => {
            if (typeof (id) === 'number') {
                this.buns.filter((elem) => elem.id === id)[0] = result;
            } else {
                this.buns.push(result);
            }
        });
    }
}
