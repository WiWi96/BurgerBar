import { Component, OnInit, Input, Output, EventEmitter, forwardRef } from '@angular/core';
import { IngredientDetails } from '../../../models/ingredient-details';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { Ingredient } from '../../../models/ingredient';
import { FormGroup } from '@angular/forms';
import { faTh, faTrashAlt } from '@fortawesome/free-solid-svg-icons';

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

    constructor(private ingredientService: IngredientService) { }

    ngOnInit() {
        this.ingredientService.getIngredients().subscribe(
            data => this.ingredients = data);
    }

    //writeValue(obj: any): void {
    //    if (obj !== undefined)
    //        this.ingredient = obj;
    //    this.onChange(this.ingredient)
    //}
    //registerOnChange(fn: any): void {
    //    this.onChange = fn;
    //}
    //registerOnTouched(fn: any) {

    //}

    //onIngredientSelected(event: any) {
    //    this.onChange(this.ingredient);
    //}

    deleteIngredient() {
        console.log(this.ingredient);
        this.deleted.emit(this.index);
    }

    ingredientSelected() {
        let id = +this.ingredientForm.get('ingredient').value.id;
        this.ingredientService.getIngredientDetails(id).subscribe(
            data => this.ingredientDetails = data
        );
    }

    compare = (a, b) => a == b;
}
