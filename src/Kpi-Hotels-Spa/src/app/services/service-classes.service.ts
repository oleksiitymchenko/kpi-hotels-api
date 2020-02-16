import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { serviceClass } from '../models/service-class';

const API_URL = environment.hotelsApiUrl;
@Injectable({
  providedIn: 'root'
})
export class ServiceClassService {

  constructor(
    private http: Http
    ) { }
  
    public getAllServiceClasses(): Observable<serviceClass[]> {
      return this.http
        .get(`${API_URL}api/ServiceClasses`)
        .pipe(
          map(response => {
            const dataList = response.json();
            return dataList.map((data) => Object.assign(new serviceClass(), data));
        }), catchError(this.handleError));
    }
  
    public createServiceClass(ServiceClass: serviceClass) {
      return this.http.post(`${API_URL}api/ServiceClasses`, ServiceClass)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public getServiceClassById(id: string): Observable<serviceClass> {
      console.log(id);
      return this.http
        .get(`${API_URL}api/ServiceClasses/${id}`)
        .pipe(
          map(response => {
            const data = response.json();
            return Object.assign(new serviceClass(), data);
        }), catchError(this.handleError));
    }
  
    public updateServiceClass(ServiceClass: serviceClass) {
      return this.http.put(`${API_URL}api/ServiceClasses/${ServiceClass.id}`, ServiceClass)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public deleteServiceClassById(id: string) {
      return this.http
        .delete(`${API_URL}api/ServiceClasses/${id}`)
        .pipe(
          map(response => { console.log(response) }), 
          catchError(this.handleError));
    }

    private handleError (error: Response | any) {
      console.error('ApiService::handleError', error);
      return Observable.throw(error);
    }
}
