import { Injectable, NgModule } from '@angular/core';
import {  HttpEvent,  HttpInterceptor,  HttpHandler,  HttpRequest} from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {
   intercept(req: HttpRequest<any>,next: HttpHandler): Observable<HttpEvent<any>> {
    const credentialsKey = 'credentials'; 
    const savedCredentials = sessionStorage.getItem(credentialsKey) || localStorage.getItem(credentialsKey);   
    if (savedCredentials) {
      var _user = JSON.parse(savedCredentials);
    }
      const dupReq = req.clone({
         headers: req.headers.set('authorization', (_user && _user.token) ? 'Bearer ' + _user.token : '')
      });
      return next.handle(dupReq);
   }
}
@NgModule({
   providers: [{
      provide: HTTP_INTERCEPTORS,
      useClass: HttpsRequestInterceptor,
      multi: true,
   }]
})
export class Interceptor { }