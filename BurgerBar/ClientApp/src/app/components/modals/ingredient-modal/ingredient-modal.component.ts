import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { IngredientType } from '../../../models/ingredient-type';
import { IngredientDetails } from '../../../models/ingredient-details';
import { Subject } from 'rxjs';
import { BunDetails } from '../../../models/bun-details';

@Component({
    selector: 'app-ingredient-modal',
    templateUrl: './ingredient-modal.component.html',
    styleUrls: ['./ingredient-modal.component.scss']
})
export class IngredientModalComponent implements OnInit {
    public onClose: Subject<BunDetails>;

    id: any;
    ingredientTypes: IngredientType[];
    ingredient: IngredientDetails = new IngredientDetails();

    constructor(public bsModalRef: BsModalRef,
        private ingredientsService: IngredientService) { }

    ngOnInit() {
        this.onClose = new Subject();
        this.ingredientsService.getIngredientTypes().subscribe(
            data => this.ingredientTypes = data);
        if (typeof (this.id) === 'number') {
            this.ingredientsService.getIngredientDetails(this.id).subscribe(data => this.ingredient = data);
        }
    }

    saveIngredient() {
        if (typeof (this.id) === 'number') {
            this.ingredientsService.putIngredient(this.id, this.ingredient).subscribe(data => this.onSuccess(data));
        } else {
            this.ingredientsService.postIngredient(this.ingredient).subscribe(data => this.onSuccess(data));
        }
    }

    onSuccess(data) {
        this.onClose.next(data);
        this.bsModalRef.hide();
    }

    compareTypes = (a, b) => a && b && a.id === b.id;
}
