import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, mergeMap, tap } from 'rxjs/operators';
import { MessageService } from '../servicers/message.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private ar: ActivatedRoute, private messageService: MessageService,
    private dialogService: DialogService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(tap(() => { },
      (err: any) => {
        if (err instanceof HttpErrorResponse) {
          switch (err.status) {
            case 401:
              const url = this.router.url;
              if (url.startsWith('/public/') || url.startsWith('/ban-do') || url.startsWith('/ban-do-dp')) {
                break;
              }
              this.router.navigateByUrl('/public/account/login');
              break;
            case 403:
              this.dialogService.error('Thông báo', "Phiên đăng nhập hết hạn. Vui lòng đăng nhập lại").then(x=>{
                this.router.navigate(['/public','account','logout']);
              });
              break;
            case 404:
              this.router.navigateByUrl('/error/404');
              break;
          }
        }
      }));
  }
}
