import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/classes/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(public us: UserService, public router: Router) { }

  ngOnInit(): void {
    this.us.galery=true
    this.us.uu=new user()
  }
  //הוספת משתמש וניתוב המשתמש החדש
  check() {
    
      this.us.addUser().subscribe(
        succ => {
          debugger
          console.log(succ)
          if (succ != -1) {
            this.us.userId=succ
            this.us.userConnect = false
            this.us.FullName = `שלום ל${this.us.uu.UserFirstName} ${this.us.uu.UserLastName}`
            this.router.navigate(['לטיולים שלנו'])
          }
        },
        err => { debugger
          alert(err.message) }
      )
  }

}
