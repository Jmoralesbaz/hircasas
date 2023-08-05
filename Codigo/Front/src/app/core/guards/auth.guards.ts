import { Injectable } from "@angular/core";
import { ActivatedRoute, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { RoutsNavigation } from "@pdata/constants/navigations";
import { AuthenticationService } from "@pdata/services/authentication.service";

import { Observable } from "rxjs";
const ROUTS = RoutsNavigation.Access;
@Injectable({
    providedIn: 'root'
  })
export class AuthGuards {
    constructor(private router: Router,private routing:ActivatedRoute,
      private srvAuth:AuthenticationService){}
    canActivate(
      state:RouterStateSnapshot
    ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        const userCurrent =this.srvAuth.getUser;
         if (userCurrent) {          
           return true;
           }else{             
             this.router.navigate([
               `${ROUTS.Path}`
             ],{
               queryParams:{returnUrl:state.url}
             }             
               );
            return false;
         }
   
          
    }
}
