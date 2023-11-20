import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/classes/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css']
})
export class SignOutComponent implements OnInit{
  constructor(public us:UserService,public r:Router){}
  ngOnInit(): void {
   this.us.galery=false//להצגת מסך הגלריה
   this.us.uu=new user()
   this.us.userId=0
   this.us.FullName="שלום וברכה"
   this.us.userConnect=true;
   this.us.manegerConnect=true;
  }

}
