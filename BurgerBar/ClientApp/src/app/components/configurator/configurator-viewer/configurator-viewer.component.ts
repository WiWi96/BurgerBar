import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BurgerService } from '../../../services/burger/burger.service';
import { Burger } from '../../../models/burger';
import { faAngleDown } from '@fortawesome/free-solid-svg-icons';
import { FileService } from '../../../services/file/file.service';
import { CartService } from '../../../services/cart/cart.service';

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
        private router: Router,
        private service: BurgerService,
        private fileService: FileService,
        private cartService: CartService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);

        if (this.code) {
            this.service.getBurgerByCode(this.code).subscribe(
                data => this.burger = data,
                _ => {
                    this.router.navigate(['/configure']);
                }
            );
        }
    }

    expandDetails() {
        this.showDetails = true;
    }

    order() {
        this.cartService.addProduct(this.burger);
    }
}
