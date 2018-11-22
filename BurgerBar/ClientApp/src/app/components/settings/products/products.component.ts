import { Component, OnInit } from '@angular/core';
import { ProductType } from '../../../models/product-type';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { ProductService } from '../../../services/product/product.service';
import { ProductModalComponent } from '../../modals/product-modal/product-modal.component';
import { Product } from '../../../models/product';

@Component({
    selector: 'app-products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
    products: Product[];
    types: ProductType[];
    faWrench = faWrench;

    bsModalRef: BsModalRef;

    constructor(private service: ProductService,
        private modalService: BsModalService) { }

    ngOnInit() {
        this.getProductTypes();
        this.getProducts();
    }

    getProducts() {
        this.service.getProducts().subscribe(data => this.products = data);
    }

    getProductTypes() {
        this.service.getProductTypes().subscribe(data => this.types = data);
    }

    addProduct() {
        this.openProductModal();
    }

    editProduct(index: number) {
        this.openProductModal(index);
    }

    getProductsOfType(type: ProductType): Product[] {
        if (this.products) {
            return this.products.filter(x => (x.typeId === type.id));
        }
        return null;
    }

    openProductModal(index?: any) {
        const initialState = {
            id: typeof (index) === 'number' ? this.products[index].id : null
        };
        this.bsModalRef = this.modalService.show(ProductModalComponent, { initialState });
        this.bsModalRef.content.onClose.subscribe(result => {
            if (typeof (index) === 'number') {
                this.products[index] = result;
            } else {
                this.products.push(result);
            }
        });
    }
}
