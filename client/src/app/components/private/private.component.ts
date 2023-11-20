import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { findIndex } from 'rxjs';
import { kind } from 'src/app/classes/kind';
import { order } from 'src/app/classes/order';
import { trip } from 'src/app/classes/trip';
import { user } from 'src/app/classes/user';
import { OrderService } from 'src/app/services/order.service';
import { TripService } from 'src/app/services/trip.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-private',
  templateUrl: './private.component.html',
  styleUrls: ['./private.component.css']
})
export class PrivateComponent implements OnInit{
  x: any;
  constructor(private datePipe:DatePipe, public r:Router,public us:UserService,public ts:TripService,public os:OrderService){}
  u:user=new user(this.us.userId)
  lo:Array<order>=new Array<order>()
  listUserTrips:Array<trip>=new Array<trip>()
  listUserTripsNotFilters:Array<trip>=new Array<trip>()
  allKinds:Array<kind>=new Array<kind>()
  public nowDate:string="";
  public now:Date=new Date();
  public filterPrice:string=""
  public filterDate:string=""
  public chooseKind:number=0
  try=true
  //האם להציג את כפתור ביטול הזמנה לפי תאריך הטיול
  showb(thisdate:Date){
    return new Date(thisdate||0)>new Date()
  }
  //סינון עפ"י סוג הטיול
  kindFilter()
  {
    this.listUserTrips=this.listUserTripsNotFilters
    this.listUserTrips=this.listUserTripsNotFilters.filter(x=>x.KindId==this.chooseKind)
  }
  //מיון עפ"י המחיר
  sortByPrice(){
    if(this.filterPrice=="0")
    this.listUserTrips=this.listUserTripsNotFilters.sort((a,b)=>a.TripPrice!-b.TripPrice!)
    else
    this.listUserTrips=this.listUserTripsNotFilters.sort((a,b)=>b.TripPrice!-a.TripPrice!)
  }
  //סינון עפ"י תאריך
  dateFilter(){
    if(this.filterDate=="0")
    this.listUserTrips=this.listUserTripsNotFilters.filter(x=>new Date(x.TripDate||0)<new Date())
    else
    this.listUserTrips=this.listUserTripsNotFilters.filter(x=>new Date(x.TripDate||0)>=new Date())
  }
  //להצגה חוזרת של כל הטיולים
  funcAllTrips(){
    this.listUserTrips=this.listUserTripsNotFilters
  }
ngOnInit(): void {
  //בסוגי הטיולים selectמילוי ה
  this.ts.getAllKind().subscribe(
    succ=>this.allKinds=succ,
    err=>alert(err.message)
  )
  //הצגת כל הטיולים של המשתמש
  this.us.getAllTripToUser(this.us.userId).subscribe(
    succ=>{
    this.listUserTrips=succ
    this.listUserTripsNotFilters=succ}
  )
}
toShow(n:number){
  debugger
  //n=2=>  "הצגת איזור "הטיולים שלי
  //n=1=>  "הצגת איזור "עריכת פרטים אישיים
  this.x=document.getElementsByTagName("section")
  this.x[n].hidden=false
  //הסתרת הכפתורים
  document.getElementById("1")!.hidden=true
}
//עדכון פרטים אישיים
updatePersonalDeatails()
{
  debugger
    this.us.updateUser().subscribe(
      succ => {
        console.log(succ)
        if (succ==true)
        {
         alert("הפרטים עודכנו בהצלחה")
         this.us.FullName="שלום ל"+this.us.uu.UserFirstName+" "+this.us.uu.UserLastName
        }
        else alert("העדכון אינו הצליח, כנראה היו שגיאות בפרטים שהזנת...")
      },
      err => { alert(err.message) }
    )
  }
  //מחיקת משתמש
  delUser(){
    alert("המשתמש ימחק מהאתר ולא ישמרו פרטי המשתמש")
    this.us.deleteUser(this.us.userId).subscribe(
      succ=>{
        if(succ==true){
          alert("הוסרת בהצלחה")
          this.us.uu=new user()
          this.us.userId=0
          this.us.FullName="שלום וברכה"
          this.us.userConnect=true;
          this.r.navigate(['/התנתקות']);
      }
          else
          alert("אין אפשרות למחוק משתמש שהזמין טיולים")
      },
      err=>{alert(err)}
    )
  }
  //ביטול הזמנה
  notOrder(id:number){
    this.os.GetAllToTrip(id).subscribe(
      succ=>{
        this.lo=succ
        console.table(this.lo)
        this.lo=this.lo.filter(x=>x.UserId==this.us.userId)
        console.table(this.lo)
        this.os.DeleteOrder(this.lo[0].OrderId!).subscribe(
          succ=>{
            debugger
                  if(succ==true){
                    console.log(this.listUserTrips.findIndex(x=>x.TripId==this.lo[0].TripId))
                    if(this.listUserTrips.length==1)
                      this.listUserTrips=new Array<trip>()
                      else
                    this.listUserTrips=this.listUserTrips.slice(this.listUserTrips.findIndex(x=>x.TripId==this.lo[0].TripId),1)
                    alert("ההזמנה בוטלה בהצלחה!")
                  }
                  else
                  alert("התרחשה שגיאה בעת מחיקת הזמנתך מטיול זה...")
                  },
                err=>{
                  alert(err)
                })

      },
      err=>{
          alert(err.message)
      })
  }
}