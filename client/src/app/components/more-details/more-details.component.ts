import { Component, OnInit } from '@angular/core';
import { order } from 'src/app/classes/order';
import { TripService } from 'src/app/services/trip.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-more-details',
  templateUrl: './more-details.component.html',
  styleUrls: ['./more-details.component.css']
})
export class MoreDetailsComponent implements OnInit{
  public doOrder:boolean=true
  public o:order=new order()
  constructor(public ts:TripService,public us:UserService){}
  ngOnInit(): void {}
  // הזמנת מקומות לטיול
  order(){
    if(this.o.OrderPlaces!>this.ts.tripDetails.TripAvailability!)
        alert("אין מספיק מקומות בטיול...")
   else{
    this.o.UserId=this.us.userId
    this.o.OrderDate=new Date()
    let d=new Date()
    debugger
    this.o.TripId=this.ts.tripDetails.TripId
    this.ts.addInviteToTrip(this.o).subscribe(
      succ=>{
        if(succ!=-1)
        {
          alert("ההזמנה בוצעה בהצלחה")
          this.doOrder=true
          this.ts.tripDetails.TripAvailability!-=this.o.OrderPlaces!
        }
        else
          alert("התרחשה שגיאה במהלך ביצוע ההזמנה...")
      },
      err=>{alert(err.message)}
    )}
  }  
}
