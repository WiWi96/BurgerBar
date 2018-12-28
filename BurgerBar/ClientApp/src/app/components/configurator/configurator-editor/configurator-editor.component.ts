import { Component, OnInit, ViewChild } from '@angular/core';
import { BurgerService } from '../../../services/burger/burger.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BurgerDetails } from '../../../models/burger-details';
import { BunService } from '../../../services/bun/bun.service';
import { Bun } from '../../../models/bun';
import { Ingredient } from '../../../models/ingredient';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { BunDetails } from '../../../models/bun-details';
import { ValidationService } from '../../../services/validation/validation.service';
import { FileService } from '../../../services/file/file.service';

@Component({
    selector: 'app-configurator-editor',
    templateUrl: './configurator-editor.component.html',
    styleUrls: ['./configurator-editor.component.scss']
})
export class ConfiguratorEditorComponent implements OnInit {
    public form: FormGroup;

    buns: Bun[] = [];
    ingredients: Ingredient[] = [];
    bun: BunDetails;
    price = 0.0;
    formSubmitted: boolean = false;

    constructor(private activatedRoute: ActivatedRoute,
        private router: Router,
        private formBuilder: FormBuilder,
        private burgerService: BurgerService,
        private bunService: BunService,
        private validationService: ValidationService,
        private fileService: FileService
    ) { }

    ngOnInit() {
        let code: string;
        this.activatedRoute.params.subscribe(params => code = params.code);

        this.bunService.getAvailableBuns().subscribe(data => this.buns = data);

        this.form = this.formBuilder.group({
            name: ['', [Validators.required, Validators.minLength(5)]],
            bun: ['', [Validators.required]],
            ingredients: this.formBuilder.array([
                this.initIngredient()
            ], this.validationService.minLengthArray(2))
        });

        if (code) {
            this.burgerService.getBurgerByCode(code).subscribe(data => {
                const burger = data;
                this.form.patchValue(burger);

                const ingredientsFGs = burger.ingredients.map(item => this.initIngredient(item));
                const ingredientsFormArray = this.formBuilder.array(ingredientsFGs);
                this.form.setControl('ingredients', ingredientsFormArray);

                this.bunSelected();
            });
        }

        this.onChanges();
    }

    onChanges(): void {
        this.form.valueChanges.subscribe(val => {
            this.price = val.bun ? val.bun.price : 0.0;
            val.ingredients.forEach(item => {
                if (item.ingredient)
                    this.price += item.ingredient.price;
            });
        });
    }

    initIngredient(model = null) {
        return this.formBuilder.group({
            ingredient: [model, [Validators.required]]
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
        this.formSubmitted = true;
        let tmpModel = { ...model.value };

        tmpModel.bun = tmpModel.bun.id;
        tmpModel.ingredients = tmpModel.ingredients.map(o => o.ingredient.id);

        this.burgerService
            .postBurger(tmpModel)
            .subscribe(
                data => this.router.navigateByUrl(`/configure/${data.code}`),
                _ => {
                    this.formSubmitted = false
                });
    }

    bunSelected() {
        let id = +this.form.get('bun').value.id;
        this.bunService.getBunDetails(id).subscribe(
            data => this.bun = data
        );
    }

    compare = (a, b) => a && b ? a.id === b.id : a === b;

}
