import { Time } from "@angular/common";

export class trip{
   
    constructor(public TripId:number, public TripDestination?:string, public KindId?:number, public TripDate?:Date, public TripTime?:Time, public TripHour?:number, public TripAvailability?:number, public TripPrice?:number, public TripImage?:string,public KindName?:string,public Paramedic?:boolean ) { }
}