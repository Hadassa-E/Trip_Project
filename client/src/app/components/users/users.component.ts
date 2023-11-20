import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/classes/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  constructor(public us:UserService, public router: Router){}
  public lusers: Array<user>=new Array<user>() 
  ngOnInit(): void {
//הצגת כל המשתמשים
    this.us.getAllUsers().subscribe(
      succ => {
        this.lusers=succ
      },
      err => {
        console.log(err)
      }
    )
  }
  
}
