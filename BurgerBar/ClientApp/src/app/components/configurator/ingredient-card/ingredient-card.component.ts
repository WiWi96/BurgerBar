import { Component, OnInit, Input, Output, EventEmitter, forwardRef } from '@angular/core';
import { IngredientDetails } from '../../../models/ingredient-details';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { Ingredient } from '../../../models/ingredient';
import { FormGroup } from '@angular/forms';
import { faTh, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { FileService } from '../../../services/file/file.service';

@Component({
    selector: 'app-ingredient-card',
    templateUrl: './ingredient-card.component.html',
    styleUrls: ['./ingredient-card.component.scss']
})
export class IngredientCardComponent implements OnInit {//, ControlValueAccessor {
    ingredient: Ingredient;
    ingredientDetails: IngredientDetails;

    faTh = faTh;
    faTrashAlt = faTrashAlt;

    @Input()
    index: number;

    @Input('group')
    ingredientForm: FormGroup;

    @Output()
    deleted = new EventEmitter<number>();

    ingredients: Ingredient[] = [];

    constructor(private ingredientService: IngredientService,
    private fileService: FileService) { }

    ngOnInit() {
        this.ingredientService.getAvailableIngredients().subscribe(
            data => {
                this.ingredients = data
                this.ingredientSelected();
            });
    }

    deleteIngredient() {
        this.deleted.emit(this.index);
    }

    ingredientSelected() {
        if (this.ingredientForm.get('ingredient').value) {
            const id = +this.ingredientForm.get('ingredient').value.id;
            this.ingredientService.getIngredientDetails(id).subscribe(
                data => this.ingredientDetails = data
            );
        }
    }

    get ingredientSelect() {
        return this.ingredientForm.get('ingredient');
    }

    compare = (a, b) => a && b ? a.id === b.id : a === b;
}
