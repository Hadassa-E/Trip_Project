import { withRequestsMadeViaParent } from '@angular/common/http';
import { Component, OnInit, SecurityContext } from '@angular/core';
import { Route, Router } from '@angular/router';
import { kind } from 'src/app/classes/kind';
import { trip } from 'src/app/classes/trip';
import { TripService } from 'src/app/services/trip.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-page-trips',
  templateUrl: './page-trips.component.html',
  styleUrls: ['./page-trips.component.css']
})
export class PageTripsComponent implements OnInit{
  constructor(public ts:TripService,public us:UserService,public router: Router){}
  allTrips:Array<trip>=new Array<trip>()
  allTripsToKind:Array<trip>=new Array<trip>()
  allKinds:Array<kind>=new Array<kind>()
  t1:trip=new trip(0)
  public filterPrice:string=""
  public filterDate:string=""
  public chooseKind:number=0
  //סינון עפ"י סוג הטיול
  kindFilter()
  {
    this.allTripsToKind=this.allTrips
    this.allTripsToKind=this.allTripsToKind.filter(x=>x.KindId==this.chooseKind)
  }
  //מעבר לפרטי טיול שלחצו עליו
  moreDetails(trip:trip)
  {
    this.ts.tripDetails=trip
    this.router.navigate(['פרטי טיול'])
  }
  ngOnInit(): void {
    this.us.galery=true//להסתרת הגלריה
    this.ts.getAllTripsToShow().subscribe(//הצגת כל הטיולים שעדיין לא היו
      succ=>{this.allTrips=succ
        this.allTripsToKind=succ
      console.table(this.allTrips)},
      err=>{alert(err.message)}
    )
   this.ts.getAllKind().subscribe(
    succ=>{this.allKinds=succ
    console.table(this.allTrips)},
    err=>{alert(err.message)}
  )
  console.log(this.chooseKind)
  }
}
