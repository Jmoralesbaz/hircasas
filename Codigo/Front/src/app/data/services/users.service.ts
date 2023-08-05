import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { Users } from '@pdata/interfaces/iusers';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Users;
@Injectable({
  providedIn: 'root'
})
export class UsersService extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }
  public getAll(): Observable<Users[]> {    
    return this.Get(routs.Accions.All);
  }
  public add(data: Users): Observable<number> {
    return this.Post<number,Users>(routs.Accions.Add,data);
  }
  public edit<TOut, TInt>(id:any,data: TInt): Observable<TOut> {
    return this.Put(`${routs.Accions.Update}${id}`,data);
  }
  public asset(id:any): Observable<number> {
    return this.Put(`${routs.Accions.Asset}${id}`,undefined);
  }
}
