import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { order } from '../classes/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  url:string='https://localhost:7212/api/Trips/'
  constructor(public http:HttpClient) { }
  //serviceקריאות שרת ב
  DeleteOrder(id:number):Observable<boolean>
  {
    return this.http.delete<boolean>(`${this.url}DeleteOrder/${id}`)
  }
  GetAllToTrip(id:number):Observable<Array<order>>
  {
    return this.http.get<Array<order>>(`${this.url}GetAllToTrip/${id}`)
  }
}
