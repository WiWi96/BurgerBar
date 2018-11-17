import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { IngredientType } from '../../../models/ingredient-type';
import { Ingredient } from '../../../models/ingredient';

@Component({
    selector: 'app-ingredient-modal',
    templateUrl: './ingredient-modal.component.html',
    styleUrls: ['./ingredient-modal.component.scss']
})
export class IngredientModalComponent implements OnInit {

    private ingredientTypes: IngredientType[];
    editedItem: Ingredient;
    ingredient: Ingredient;
    items: Array<Ingredient> = [];

    constructor(public bsModalRef: BsModalRef,
        private ingredientsService: IngredientService) { }

    ngOnInit() {
        this.ingredientsService.getIngredientTypes().subscribe(
            data => this.ingredientTypes = data);
        this.ingredient = { ...this.editedItem };
    }

    saveIngredient() {
        if (this.editedItem) {
            this.ingredientsService.putIngredient(this.editedItem.id, this.ingredient).subscribe(data => {
                var index = this.items.findIndex(el => this.compareTypes(el, data));
                if (index > -1)
                    this.items[index] = data;
            });
        }
        else {
            this.ingredientsService.postIngredient(this.ingredient).subscribe(data => this.items.push(data));
        }
        this.bsModalRef.hide();
    }

    compareTypes = (a, b) => a.id === b.id;

}
