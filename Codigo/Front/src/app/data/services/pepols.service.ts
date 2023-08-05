import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { Person } from '@pdata/interfaces/iperson';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Persons;
@Injectable({
  providedIn: 'root'
})
export class PepolsService extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }

  public getAll(): Observable<Person[]> {
    
    return this.Get(routs.Accions.All);
  }
  public add(data: Person): Observable<number> {
    return this.Post<number,Person>(routs.Accions.Add,data);
  }
  public edit(id:number,data:Person): Observable<number> {
    return this.Put(`${routs.Accions.Update}${id}`,data);
  }
  public asset(id:number): Observable<number> {
    return this.Put(`${routs.Accions.Asset}${id}`,undefined);
  }
}
