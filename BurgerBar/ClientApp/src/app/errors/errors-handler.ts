import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { NotificationService } from '../services/notification/notification.service';
import { forEach } from '@angular/router/src/utils/collection';

@Injectable()
export class ErrorsHandler implements ErrorHandler {
    constructor(
        private injector: Injector,
    ) { }

    handleError(error: Error | HttpErrorResponse) {
        const router = this.injector.get(Router);
        const notificationService = this.injector.get(NotificationService);
        if (error instanceof HttpErrorResponse) {
            if (!navigator.onLine) {
                return notificationService.notify('There is no Internet connection.');
            } else {
                let message;
                switch (error.status) {
                    case 401:
                    case 403:
                        message = 'You don\'t have permissions to access.';
                        break;
                    case 400:
                        if (error.error) {
                            message = '';
                            for (let propertyName in error.error) {
                                (error.error[propertyName] as []).forEach(value => message += value + ' ');
                            }
                        }
                        else {
                            message = 'The request was invalid';
                        }
                        break;
                    case 404:
                        message = 'The resource is unable to be found.';
                        break;
                    default:
                        message = 'An unknown error occured.';
                        break;
                }
                return notificationService.notify(message);
            }
        } else {
            return notificationService.notify(error.message);
        }
    }
}
