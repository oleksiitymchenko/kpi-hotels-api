import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { Http } from '@angular/http';
import { order } from '../models/order';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

const API_URL = environment.hotelsApiUrl;
@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(
    private http: Http
    ) { }
  
    public getAllOrders(): Observable<order[]> {
      return this.http
        .get(`${API_URL}api/orders`)
        .pipe(
          map(response => {
            const dataList = response.json();
            return dataList.map((data) => Object.assign(new order(), data));
        }), catchError(this.handleError));
    }
  
    public createOrder(Order: order) {
      return this.http.post(`${API_URL}api/orders`, Order)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public getOrderById(id: string): Observable<order> {
      console.log(id);
      return this.http
        .get(`${API_URL}api/orders/${id}`)
        .pipe(
          map(response => {
            const data = response.json();
            return Object.assign(new order(), data);
        }), catchError(this.handleError));
    }
  
    public updateOrder(Order: order) {
      return this.http.put(`${API_URL}api/orders/${Order.id}`, Order)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public deleteOrderById(id: string) {
      return this.http
        .delete(`${API_URL}api/orders/${id}`)
        .pipe(
          map(response => { console.log(response) }), 
          catchError(this.handleError));
    }

    private handleError (error: Response | any) {
      console.error('ApiService::handleError', error);
      return Observable.throw(error);
    }
}
