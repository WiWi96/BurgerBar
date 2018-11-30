import { Component, OnInit, Input, Output, EventEmitter, forwardRef } from '@angular/core';
import { IngredientDetails } from '../../../models/ingredient-details';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { Ingredient } from '../../../models/ingredient';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-ingredient-card',
    templateUrl: './ingredient-card.component.html',
    styleUrls: ['./ingredient-card.component.scss'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => IngredientCardComponent),
            multi: true
        }
    ]
})
export class IngredientCardComponent implements OnInit {//, ControlValueAccessor {
    //@Input()
    ingredient: IngredientDetails;
    @Input()
    index: number;

    @Input('group')
    ingredientForm: FormGroup;

    @Output()
    deleted = new EventEmitter<number>();

    //onChange = (_: any) => {};

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

    compare = (a, b) => a && b && a.id == b.id;
}
