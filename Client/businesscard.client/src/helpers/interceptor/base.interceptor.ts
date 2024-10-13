import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

import { LoaderService } from '../../utils/loader.service';
import { SwalHelpers } from '../../utils/swal-helpers';

@Injectable()
export class BaseInterceptor implements HttpInterceptor {

  constructor(private loaderService: LoaderService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error) => {
        return this.handleError(error);
      }));
  }

  
  private handleError(response: HttpErrorResponse): Observable<any> {

      if (response.error.message != null)
        SwalHelpers.SwalError(response.error.message, "Ok, got it!");
      else
        SwalHelpers.SwalError("Sorry, looks like there are some errors detected, please try again.", "Ok, got it!");

    //this.loaderService.setLoading(false);
    return throwError(response);
  }

}
