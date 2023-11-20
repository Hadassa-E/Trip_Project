import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { kind } from 'src/app/classes/kind';
import { trip } from 'src/app/classes/trip';
import { TripService } from 'src/app/services/trip.service';

@Component({
  selector: 'app-we-trips',
  templateUrl: './we-trips.component.html',
  styleUrls: ['./we-trips.component.css']
})
export class WeTripsComponent implements OnInit {
  constructor(public ts: TripService, public router: Router) { }
  public chooseKind: number = 0
  allTrips: Array<trip> = new Array<trip>()
  allTripsToKind: Array<trip> = new Array<trip>()
  allKinds: Array<kind> = new Array<kind>()
  public chooseDate: string = "-1"
  public DateOftoday: Date = new Date()
  public week: Date = new Date(this.DateOftoday.getDate() + 7, this.DateOftoday.getMonth(), this.DateOftoday.getFullYear())
  public month: Date = new Date(new Date().setMonth(this.DateOftoday.getMonth() + 1))
  ngOnInit(): void {
    this.ts.getAllTrips().subscribe(//להצגת כל הטיולים
      succ => {
        this.allTrips = succ
        this.allTripsToKind = succ
        console.table(this.allTrips)
      },
      err => { alert(err.message) }
    )
    this.ts.getAllKind().subscribe(//למילוי הסלקט של הסוגים
      succ => {
        this.allKinds = succ
        console.table(this.allTrips)
      },
      err => { alert(err.message) }
    )
    console.log(this.chooseKind)
  }
  //סינון עפ"י סוג הטיול
  kindFilter() {
    this.allTripsToKind = this.allTrips
    this.allTripsToKind = this.allTripsToKind.filter(x => x.KindId == this.chooseKind)
  }
  //להצגה חוזרת של כל הטיולים
  funcAllTrips() {
    this.allTripsToKind = this.allTrips
  }
  //כל הסינונים לפי התאריך
  dateFilter() {
debugger
    switch (this.chooseDate) {
      //טיולים מהעבר
      case "0":
        this.allTripsToKind = this.allTripsToKind.filter(x => new Date(x.TripDate!) < this.DateOftoday)
        break
      //טיולים היום
      case "1":
        this.allTripsToKind = this.allTripsToKind.filter(x => new Date(x.TripDate!)== this.DateOftoday)
        break
      //טיולים בשבוע הקרוב
      case "2":
        this.allTripsToKind = this.allTripsToKind.filter(x => new Date(x.TripDate!)>= this.DateOftoday&&new Date(x.TripDate!) <= this.week)
        break
      //טיולים בחודש הקרוב
      case "3":
        this.allTripsToKind = this.allTripsToKind.filter(x => new Date(x.TripDate!)>= this.DateOftoday&&new Date(x.TripDate!) <= this.month)
        break
      //טיולים מהעתיד
      case "4":
        this.allTripsToKind = this.allTripsToKind.filter(x => new Date(x.TripDate!) > this.DateOftoday)
        break
    }
  }
  //מעבר לקומפוננטת עריכה
  edit(id:number){
    this.ts.editTripId=id
    console.log(this.ts.editTripId)
    this.router.navigate(["./עריכת טיול"])
  }
}
