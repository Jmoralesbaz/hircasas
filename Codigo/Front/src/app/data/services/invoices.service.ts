import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoutsServices } from '@pdata/constants/services';
import { Invoice } from '@pdata/interfaces/iinvoice';
import { Service } from '@pdata/schemas/base';
import { Observable } from 'rxjs';
const routs = RoutsServices.Api.Sources.Seccions.Invoices;
@Injectable({
  providedIn: 'root'
})
export class InvoicesService  extends Service {

  constructor(http: HttpClient) {
    super(http);
    this.pathService = `${RoutsServices.Api.URL}${routs.PATH}`;

  }

  public getAll(): Observable<Invoice[]> {
    
    return this.Get(routs.Accions.All);
  }
  public add(data: Invoice): Observable<number> {
    return this.Post<number,Invoice>(routs.Accions.Add,data);
  }
  public edit(id:string,data:Invoice): Observable<number> {
    return this.Put(`${routs.Accions.Update}${id}`,data);
  }
}
