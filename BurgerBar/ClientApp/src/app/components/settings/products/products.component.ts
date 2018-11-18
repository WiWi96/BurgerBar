import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductType } from '../../../models/product-type';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { ProductService } from '../../../services/product/product.service';
import { ProductModalComponent } from '../../modals/product-modal/product-modal.component';

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

    editProduct(product: Product) {
        this.openProductModal(product);
    }

    getProductsOfType(type: ProductType): Product[] {
        if (this.products) {
            return this.products.filter(x => (x.type && x.type.id === type.id));
        }
        return null;
    }

    openProductModal(product?: Product) {
        const initialState = {
            editedItem: product,
            items: this.products
        }
        this.bsModalRef = this.modalService.show(ProductModalComponent, { initialState });
    }
}
