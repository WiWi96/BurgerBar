import { Component, OnInit, ViewChild } from '@angular/core';
import { BurgerService } from '../../../services/burger/burger.service';
import { ActivatedRoute } from '@angular/router';
import { BurgerDetails } from '../../../models/burger-details';
import { BunService } from '../../../services/bun/bun.service';
import { Bun } from '../../../models/bun';
import { Ingredient } from '../../../models/ingredient';
import { IngredientDetails } from '../../../models/ingredient-details';
import { SortableComponent } from 'ngx-bootstrap';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { CdkDragDrop } from '@angular/cdk/drag-drop';

@Component({
    selector: 'app-configurator-editor',
    templateUrl: './configurator-editor.component.html',
    styleUrls: ['./configurator-editor.component.scss']
})
export class ConfiguratorEditorComponent implements OnInit {
    public form: FormGroup;
    burger: BurgerDetails;
    buns: Bun[] = [];
    ingredients: Ingredient[] = [];
    code: string;

    constructor(private activatedRoute: ActivatedRoute,
        private formBuilder: FormBuilder,
        private burgerService: BurgerService,
        private bunService: BunService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(params => this.code = params.code);
        if (this.code) {

        }
        else {
            this.burger = new BurgerDetails();
            this.burger.ingredients = [new IngredientDetails(), new IngredientDetails()];
        }
        this.bunService.getBuns().subscribe(data => this.buns = data);

        this.form = this.formBuilder.group({
            //name: ['', [Validators.required, Validators.minLength(5)]],
            bun: ['', [Validators.required]],
            ingredients: this.formBuilder.array([
                this.initIngredient(),
            ])
        });
    }

    initIngredient() {
        return this.formBuilder.group({
            ingredient: ['', Validators.required],
        });
    }

    @ViewChild(SortableComponent) sortableComponent: SortableComponent;

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
        items.removeAt(previousIndex);;
        items.insert(newIndex, currentGroup)
    }

    save(model: BurgerDetails) {
        console.log(model);
    }

    compare = (a, b) => a && b && a.id == b.id;

}
