import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {
  constructor(public s:UserService){}
  ngOnInit():void {  
    console.log(this.s.galery)
    this.s.galery=false;//הצגת הגלריה בעמוד הבית
    //local storageשמירת פרטי מנהל ב
    window.localStorage.setItem("managerMail", "Ortal2002@gmail.com")
    window.localStorage.setItem("managerPassword", "Ortal2002")
    window.localStorage.setItem("managerName", "אורטל נקי")
  }
}
