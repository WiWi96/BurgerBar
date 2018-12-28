import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { IngredientService } from '../../../services/ingredient/ingredient.service';
import { IngredientType } from '../../../models/ingredient-type';
import { IngredientDetails } from '../../../models/ingredient-details';
import { Subject } from 'rxjs';
import { BunDetails } from '../../../models/bun-details';
import { FileService } from '../../../services/file/file.service';
import { File } from '../../../models/file';
import { environment } from '../../../../environments/environment';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

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
    photo: File;

    //faTimes = faTimes;

    //@ViewChild('fileInput') fileInput: any;

    constructor(public bsModalRef: BsModalRef,
        private ingredientsService: IngredientService,
        private fileService: FileService) { }

    ngOnInit() {
        this.onClose = new Subject();
        this.ingredientsService.getIngredientTypes().subscribe(
            data => this.ingredientTypes = data);
        if (typeof (this.id) === 'number') {
            this.ingredientsService.getIngredientDetails(this.id).subscribe(data => {
                this.ingredient = data;
                this.photo = data.picture;
            });
        }
    }

    saveIngredient() {
        this.ingredient.picture = this.photo;
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

    //uploadPhoto() {
    //    let fi = this.fileInput.nativeElement;
    //    if (fi.files && fi.files[0]) {
    //        let fileToUpload = fi.files[0];
    //        this.fileService
    //            .upload(fileToUpload)
    //            .subscribe(res => {
    //                this.photo = res;
    //            });
    //    }
    //}

    //clearPhoto() {
    //    this.photo = null;
    //}

    photoChanged(event) {

    }

    compareTypes = (a, b) => a && b && a.id === b.id;
}
