import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CONFIG } from '@pdata/constants/config';
import { RoutsNavigation } from '@pdata/constants/navigations';
import { RoutsServices } from '@pdata/constants/services';
import { Login } from '@pdata/interfaces/ilogin';
import { Idatauder, Itoken } from '@pdata/interfaces/itoken';
import { Service } from '@pdata/schemas/base';
import { BehaviorSubject, Observable, lastValueFrom } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Authentication;
const ROUTS = RoutsNavigation.Access;
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends Service {
protected currentUser = new BehaviorSubject<Idatauder|null>(this.parseFunction());
  constructor(http: HttpClient,private router: Router) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;
  }
  public login(data: Login): Observable<any> {
    return this.Post<Itoken,Login>(routs.Accions.authenticate,data);
  }
  public async logout() {
    localStorage.clear();
    this.currentUser.next(null);
    var result = await lastValueFrom(this.Put(routs.Accions.close, {}))
    .catch((err)=>{

    });
    this.router.navigateByUrl(ROUTS.Path);
  }
  parseFunction():Idatauder|null{
    var result:Idatauder|null=null;
    var data =localStorage.getItem(CONFIG.DATAUSER)??'';
     if(data != ''){
      result = JSON.parse(atob(data));
     }
    return result;
  }
  get getUser():Idatauder|null{
    return this.currentUser.value;
  }
  setUserLocalStorage(user:Itoken){
    localStorage.setItem(CONFIG.TOKEN_NAME,user.token);
    localStorage.setItem(CONFIG.DATAUSER,btoa(JSON.stringify(user.dataUser)));
    this.currentUser.next(user.dataUser);
    this.router.navigateByUrl(`${RoutsNavigation.Operations.Path}`);
  }

  
}
