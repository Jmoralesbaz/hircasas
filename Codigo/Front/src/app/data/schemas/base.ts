import { HttpClient } from '@angular/common/http';
import { CONFIG } from '@pdata/constants/config';
import { Iparamsrequest } from '@pdata/interfaces/iparamsrequest';
import { Observable, lastValueFrom } from 'rxjs';

export abstract class Service {
  protected endPoint: string = '';
  protected pathService: string = '';


  constructor(protected http: HttpClient) {
    this.endPoint = this.getUrlBase();
  }
  private getUrlBase(): string {
    var url = CONFIG.ENDPOINT;
    var f=  url;
    return f;
  }
  protected Get<TSalida>(method: string, query: Iparamsrequest[] = []): Observable<TSalida> {
    let queryUrl = '?';
    query.forEach(f => {
      queryUrl += f.name + '=' + f.value + '&';
    });
    return this.http.get<TSalida>(this.endPoint + this.pathService + method + queryUrl.substring(0, queryUrl.length - 1));
  }

  protected Post<TSalida, TDatos>(method: string, datos: TDatos): Observable<TSalida> {
    return this.http.post<TSalida>(this.endPoint + this.pathService + method, datos);
  }
  protected Put<TSalida, TDatos>(method: string, datos: TDatos): Observable<TSalida> {
    return this.http.put<TSalida>(this.endPoint + this.pathService + method, datos);
  }
  protected Patch<TSalida, TDatos>(method: string, datos: TDatos): Observable<TSalida> {
    return this.http.patch<TSalida>(this.endPoint + this.pathService + method, datos);
  }
  protected Delete<TSalida>(method: string): Observable<TSalida> {
    return this.http.delete<TSalida>(this.endPoint + this.pathService + method);
  }
}