import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CONFIG } from "@pdata/constants/config";
import { RoutsNavigation } from "@pdata/constants/navigations";
import { Observable, tap } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class TokenInterceptor implements HttpInterceptor {
  
    constructor(private router: Router) { }
        intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
            const token: string = localStorage.getItem(CONFIG.TOKEN_NAME)??'';
      
            let request = req;
            req = req.clone({
              setHeaders: {
                  'Content-Type': 'application/json; charset=utf-8',
                  'Access-Control-Allow-Origin':CONFIG.ENDPOINT,
                  Accept: 'application/json',              
              }
          });
            if (token) {
              request = req.clone({
                setHeaders: {
                  authorization: `Bearer ${ token }`
                }
              });
            }
            return next.handle(request).pipe(tap(()=>{},(err:any)=>{
              if(err.status == 401){
                //this.alert.OpenToast('Alerta','Credencailes invalidas, inicia sesion de nuevo..','toast-warning');
                localStorage.clear();          
                window.location.href = `${window.location.origin}/${RoutsNavigation.Access.Path}`
              }
            }));
      }
  }
  