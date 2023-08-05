import { Injectable } from "@angular/core";
import { ActivatedRoute, Router, UrlTree } from "@angular/router";
import { RoutsNavigation } from "@pdata/constants/navigations";
import { AuthenticationService } from "@pdata/services/authentication.service";

import { Observable } from "rxjs";
const ROUTS = RoutsNavigation.Operations;
@Injectable({
    providedIn: 'root'
  })
export class AuthenticatedGuards {
    constructor(private router: Router,private routing:ActivatedRoute,
      private srvAuth:AuthenticationService){}
    canActivate(): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
      //console.log(this.srvAuth.getUser);
        if (this.srvAuth.getUser) {            
           this.router.navigateByUrl(`${ROUTS.Path}`);
           return false;
           }else{                        
             return true;
           }             
        
    }
}
