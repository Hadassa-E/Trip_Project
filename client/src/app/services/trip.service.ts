import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { trip } from '../classes/trip';
import { order } from '../classes/order';
import { kind } from '../classes/kind';
@Injectable({
  providedIn: 'root'
})
export class TripService {
tripDetails:trip=new trip(0)
public editTripId:number=0
url:string='https://localhost:7212/api/Trips/'
  constructor(public http:HttpClient) { }
//serviceקריאות שרת ב
  getAllTrips():Observable<Array<trip>>
  {
    return this.http.get<Array<trip>>(`${this.url}GetAllTrips`)
  }
  getAllTripsToShow():Observable<Array<trip>>
  {
    return this.http.get<Array<trip>>(`${this.url}GetAllTripsToShow`)
  }
  getTripById(id:number):Observable<trip>
  {
    return this.http.get<trip>(`${this.url}GetTripById/${id}`)
  }

  getInvitesToTripById(id:number):Observable<trip>
  {
    return this.http.get<trip>(`${this.url}GetInvitesToTripById/${id}`)
  }

  addTrip(trip:trip):Observable<number>
  {
    return this.http.post<number>(`${this.url}AddTrip`,trip)
  }

  addInviteToTrip(order:order):Observable<number>
  {
    return this.http.post<number>(`${this.url}AddInviteToTrip`,order)
  }

  updateTrip():Observable<boolean>
  {
    return this.http.put<boolean>(`${this.url}UpdateTrip`,trip)
  }

  deleteTrip(id:number):Observable<boolean>
  {
    return this.http.delete<boolean>(`${this.url}DeleteTrip/${id}`)
  }

  getAllKind():Observable<Array<kind>>
  {
    return this.http.get<Array<kind>>(`${this.url}getAllKind`)
  }
}
