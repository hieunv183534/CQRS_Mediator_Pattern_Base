import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, finalize, retry} from 'rxjs/operators';
import {Router} from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private totalRequests = 0;
  constructor(private router: Router,     
    ) {
  }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!req.headers.get('skipLoading')) {
      this.totalRequests++;      
    }
    return next.handle(req).pipe(
      retry(0),

      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          localStorage.clear();
          const url = this.router.routerState.snapshot.url;
          this.router.navigate(['/login'], { queryParams: { returnUrl: url } });
          return throwError(error);
        } else if (error.status === 403) {
          this.router.navigate(['/unauthorized']);
          return throwError(error);
        } else if (error.status === 404) {
          this.router.navigate(['/page-not-found']);
        }
        return throwError(error);
      }),
       finalize(() => {
        if (!req.headers.get('skipLoading')) {
          this.totalRequests--;
        }
        if (this.totalRequests === 0) {          
        }
      })
    );
  }
}
