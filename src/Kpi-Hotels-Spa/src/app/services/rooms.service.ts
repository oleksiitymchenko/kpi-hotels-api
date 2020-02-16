import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { Http } from '@angular/http';
import { room } from '../models/room';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

const API_URL = environment.hotelsApiUrl;
@Injectable({
  providedIn: 'root'
})
export class RoomsService {

  constructor(
    private http: Http
    ) { }
  
    public getAllRooms(): Observable<room[]> {
      return this.http
        .get(`${API_URL}api/rooms`)
        .pipe(
          map(response => {
            const dataList = response.json();
            return dataList.map((data) => Object.assign(new room(), data));
        }), catchError(this.handleError));
    }
  
    public createRoom(room: room) {
      return this.http.post(`${API_URL}api/rooms`, room)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public getRoomById(id: string): Observable<room> {
      console.log(id);
      return this.http
        .get(`${API_URL}api/rooms/${id}`)
        .pipe(
          map(response => {
            const data = response.json();
            return Object.assign(new room(), data);
        }), catchError(this.handleError));
    }
  
    public updateRoom(room: room) {
      return this.http.put(`${API_URL}api/rooms/${room.id}`, room)
      .pipe(
        map(response => { console.log(response)}),
        catchError(this.handleError)
      );
    }
  
    public deleteRoomById(id: string) {
      return this.http
        .delete(`${API_URL}api/rooms/${id}`)
        .pipe(
          map(response => { console.log(response) }), 
          catchError(this.handleError));
    }

    private handleError (error: Response | any) {
      console.error('ApiService::handleError', error);
      return Observable.throw(error);
    }
}
