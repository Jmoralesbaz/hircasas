import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { IsalesDetals, Sales } from '@pdata/interfaces/isales';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Sales;

@Injectable({
  providedIn: 'root'
})
export class SalesService extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }
  
  public getAll(): Observable<IsalesDetals[]> {
    
    return this.Get(routs.Accions.All);
  }
  public add(data: Sales): Observable<number> {
    return this.Post<number,Sales>(routs.Accions.Add,data);
  }
}
