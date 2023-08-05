import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { Item } from '@pdata/interfaces/iitem';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Items;

@Injectable({
  providedIn: 'root'
})
export class ItemsService extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }

  public getAll(): Observable<Item[]> {
    
    return this.Get(routs.Accions.All);
  }
  public add(data: Item): Observable<number> {
    return this.Post<number,Item>(routs.Accions.Add,data);
  }
  public edit(id:number,data:Item): Observable<number> {
    return this.Put(`${routs.Accions.Update}${id}`,data);
  }
  public asset(id:number): Observable<number> {
    return this.Put(`${routs.Accions.Asset}${id}`,undefined);
  }
}
