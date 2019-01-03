import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/publish';

@Injectable()
export class NotificationService {
    private _notification: BehaviorSubject<string> = new BehaviorSubject(null);
    readonly notification$: Observable<string> = this._notification.asObservable().publish().refCount();

    constructor() { }

    notify(message) {
        this._notification.next(this.truncate(message));
        setTimeout(() => this._notification.next(null), 10000);
    }

    truncate(message: string) {
        if (message.length > 100)
            return message.substring(0, 100) + '...';
        else
            return message;
    };
}
