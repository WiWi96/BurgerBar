import { Component, OnInit } from '@angular/core';
import { IngredientService } from '../../services/ingredient/ingredient.service';
import { Ingredient } from '../../models/ingredient';
import { faWrench } from '@fortawesome/free-solid-svg-icons';
import { IngredientType } from '../../models/ingredient-type';

@Component({
	selector: 'app-ingredients',
	templateUrl: './ingredients.component.html',
	styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

	ingredients: Ingredient[];
	types: IngredientType[];
	faWrench = faWrench;

	constructor(private service: IngredientService) { }

	ngOnInit() {
		this.getIngredientTypes();
		this.getIngredients();
	}

	getIngredients() {
		this.service.getIngredients().subscribe(data => this.ingredients = data);
	}

	getIngredientTypes() {
		this.service.getIngredientTypes().subscribe(data => this.types = data);
	}

	addIngredient(ingredient: Ingredient) {
		this.service.postIngredient(ingredient).subscribe(data => this.ingredients.push(data));
	}

	editIngredient(id: number, ingredient: Ingredient) {
		this.service.putIngredient(id, ingredient).subscribe(data => ingredient = data);
	}

	getIngredientsOfType(type: IngredientType): Ingredient[] {
		if (this.ingredients) {
			return this.ingredients.filter(x => x.type === type);
		}
	}
}
