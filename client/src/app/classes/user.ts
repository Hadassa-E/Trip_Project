import { order } from "./order";

export class user{
   
    constructor(public UserId?:number, public UserFirstName?:string, public UserLastName?:string, public UserPhon?:string, public UserMail?:string, public UserPassword?:string,public UserFirstAid?:boolean) { }
}