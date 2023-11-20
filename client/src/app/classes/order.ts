import { Time } from "@angular/common";
import { trip } from "./trip";


export class order{
   
    constructor(public OrderId?:number, public UserId?:number, public OrderDate?:Date, public OrderTime?:Time, public TripId?:number, public OrderPlaces?:number,public Trip?:trip) { }
}