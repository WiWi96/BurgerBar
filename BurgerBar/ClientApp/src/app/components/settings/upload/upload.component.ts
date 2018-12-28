import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { FileService } from '../../../services/file/file.service';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { File } from '../../../models/file';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
    photoValue: File = null;

    @Output() photoChange = new EventEmitter<File>();
    @Input()
    get photo(): File {
        return this.photoValue;
    }

    set photo(value: File) {
        this.photoValue = value;
        this.photoChange.emit(this.photoValue);
    }

    faTimes = faTimes;

    @ViewChild('fileInput') fileInput: any;
    constructor(private fileService: FileService) { }

    ngOnInit() {

    }

    uploadPhoto() {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.fileService
                .upload(fileToUpload)
                .subscribe(res => {
                    this.photo = res;
                });
        }
    }

    clearPhoto() {
        this.photo = null;
    }
}
