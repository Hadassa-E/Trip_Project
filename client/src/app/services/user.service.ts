import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { user } from '../classes/user';
import { trip } from '../classes/trip';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public galery:boolean=false//להצגת מסך הגלריה
   public uu:user=new user()
   public userId:number=0
   public FullName:string="שלום וברכה"
   public userConnect:boolean=true;
   public manegerConnect:boolean=true;
   url:string='https://localhost:7212/api/Users/'
   constructor(public http:HttpClient) { }
//serviceקריאות שרת ב
  getAllUsers():Observable<Array<user>>
  {
    return this.http.get<Array<user>>(`${this.url}GetAllUsers`)
  }

  getUserByMailAndPassword(mail:string,password:string):Observable<user>
  {
    return this.http.get<user>(`${this.url}GetUserByMailAndPassword/${mail}/${password}`)
  }

  addUser():Observable<number>
  { 
    return this.http.post<number>(`${this.url}AddUser`,this.uu)
  }
 

  updateUser():Observable<boolean>
  {
    return this.http.put<boolean>(`${this.url}UpdateUser`,this.uu)
  }

  deleteUser(id:number):Observable<boolean>
  {
    return this.http.delete<boolean>(`${this.url}DeleteUser/${id}`)
  }

  getAllTripToUser(id:number):Observable<Array<trip>>
  {
    return this.http.get<Array<trip>>(`${this.url}GetAllTripToUser/${id}`)
  }
}
