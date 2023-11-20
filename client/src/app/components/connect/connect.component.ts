import { DomElementSchemaRegistry } from '@angular/compiler';
import { Component, ElementRef } from '@angular/core';
import { Route, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
@Component({
  selector: 'app-connect',
  templateUrl: './connect.component.html',
  styleUrls: ['./connect.component.css']
})
export class ConnectComponent {
  UserMail: string = "";
  UserPassword: string = "";
  constructor(public us: UserService, public router: Router) { }

  ngOnInit(): void {
    this.us.galery=true
  }
  //בדיקה האם המשתמש קיים
  //ניתוב מנהל ומשתמש פשוט
  check() {
    if (this.UserMail != localStorage["managerMail"] && this.UserPassword != localStorage["managerPassword"]) {
      this.us.getUserByMailAndPassword(this.UserMail, this.UserPassword).subscribe(
        succ => {
        console.log(succ)
          if (succ != null) {
            this.us.userId=succ.UserId!
            this.us.uu=succ
            this.us.FullName = `שלום ל${succ.UserFirstName} ${succ.UserLastName}`
            this.us.userConnect = false
            this.router.navigate(['לטיולים שלנו'])
          }
          else alert("אינך קיים במערכת אנא פנה להרשמה")
        },
        err => { alert(err.message) }
      )
    }
    //מנהל
    else
    {
      this.us.manegerConnect = false
      this.us.FullName = `שלום למנהל הדסה אליאסיאן`
      this.router.navigate(['כל הטיולים'])
    }
  }

}
