import { Component, OnInit, ViewChild } from '@angular/core';
import { BurgerService } from '../../../services/burger/burger.service';
import { ActivatedRoute } from '@angular/router';
import { BurgerDetails } from '../../../models/burger-details';
import { BunService } from '../../../services/bun/bun.service';
import { Bun } from '../../../models/bun';
import { Ingredient } from '../../../models/ingredient';
import { IngredientDetails } from '../../../models/ingredient-details';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { BunDetails } from '../../../models/bun-details';
import { ValidationService } from '../../../services/validation/validation.service';
import { BurgerToAdd } from '../../../models/burger-to-add';

@Component({
    selector: 'app-configurator-editor',
    templateUrl: './configurator-editor.component.html',
    styleUrls: ['./configurator-editor.component.scss']
})
export class ConfiguratorEditorComponent implements OnInit {
    public form: FormGroup;
    burger: BurgerToAdd;
    buns: Bun[] = [];
    ingredients: Ingredient[] = [];
    code: string;
    bun: BunDetails;

    constructor(private activatedRoute: ActivatedRoute,
        private formBuilder: FormBuilder,
        private burgerService: BurgerService,
        private bunService: BunService,
        private validationService: ValidationService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);
        if (this.code) {

        }
        else {
            //this.burger = new BurgerToAdd();
        }
        this.bunService.getBuns().subscribe(data => this.buns = data);

        this.form = this.formBuilder.group({
            name: ['', [Validators.required, Validators.minLength(5)]],
            bun: ['', [Validators.required]],
            ingredients: this.formBuilder.array([
                this.initIngredient()
            ], this.validationService.minLengthArray(2))
        });
    }

    initIngredient() {
        return this.formBuilder.group({
            ingredient: ['', [Validators.required]]
        });
    }

    addIngredient() {
        const control = <FormArray>this.form.controls['ingredients'];
        control.push(this.initIngredient());
    }

    deleteIngredient(index: number) {
        const control = <FormArray>this.form.controls['ingredients'];
        control.removeAt(index);
    }

    drop(event: CdkDragDrop<string[]>) {
        const items = this.form.get('ingredients') as FormArray;

        let newIndex: number = event.currentIndex;
        let previousIndex: number = event.previousIndex;

        const currentGroup = items.at(previousIndex);
        items.removeAt(previousIndex);
        items.insert(newIndex, currentGroup)
    }

    save(model: any) {
        console.log(model.value);
        let tmpModel = { ...model.value };
        tmpModel.ingredients = model.value.ingredients.map(o => o.ingredient);
        console.log(model.value);

        this.burgerService.postBurger(tmpModel).subscribe(data => console.log(data));
    }

    bunSelected(id: number) {
        this.bunService.getBunDetails(id).subscribe(
            data => this.bun = data
        );
    }

    compare = (a, b) => a == b;

}
