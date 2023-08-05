import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { Iinventory } from '@pdata/interfaces/iinventory';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Inventory;

@Injectable({
  providedIn: 'root'
})
export class InventoryService extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }

  
  public getAll(): Observable<Iinventory[]> {
    
    return this.Get(routs.Accions.All);
  }
  public add(data: Iinventory): Observable<number> {
    return this.Post<number,Iinventory>(routs.Accions.Add,data);
  }

}
