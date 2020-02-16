import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { Http } from '@angular/http';
import { client } from '../models/Client';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

const API_URL = environment.hotelsApiUrl;
@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  constructor(
    private http: Http
    ) { }
  
    public getAllClients(): Observable<client[]> {
      return this.http
        .get(`${API_URL}api/clients`)
        .pipe(
          map(response => {
            const dataList = response.json();
            return dataList.map((data) => Object.assign(new client(), data));
        }), catchError(this.handleError));
    }
  
    public createClient(client: client) {
      return this.http.post(`${API_URL}api/clients`, client)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public getClientById(id: string): Observable<client> {
      console.log(id);
      return this.http
        .get(`${API_URL}api/clients/${id}`)
        .pipe(
          map(response => {
            const data = response.json();
            return Object.assign(new client(), data);
        }), catchError(this.handleError));
    }
  
    public updateClient(client: client) {
      return this.http.put(`${API_URL}api/clients/${client.id}`, client)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public deleteClientById(id: string) {
      return this.http
        .delete(`${API_URL}api/clients/${id}`)
        .pipe(
          map(response => { console.log(response) }), 
          catchError(this.handleError));
    }

    private handleError (error: Response | any) {
      console.error('ApiService::handleError', error);
      return Observable.throw(error);
    }
}
