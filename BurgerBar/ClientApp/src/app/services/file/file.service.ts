import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import 'rxjs/add/operator/map';
import { File } from '../../models/file';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {
    private apiPath = environment.api + '/File';

    constructor(private client: HttpClient) { }

    upload(file: any): Observable<File> {
        let input = new FormData();
        input.append("filesData", file);
        return this.client.post<File>(this.apiPath, input);
    }

    getPhotoUrl(photo: File): string {
        if (photo && photo.name)
            return `${environment.uploads}/${photo.name}`;
    }
}
