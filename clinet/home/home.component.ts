import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { UserService } from 'src/app/services/user.service';
import { LoginComponent } from 'src/app/users/login/login.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  logo:string="assets/img/logo.png"

  constructor(public dialog:MatDialog,public userService:UserService, public soundsService:SoundsService, private router :Router) { }
  userEmail:any=localStorage.getItem("email");
  userRole:any=localStorage.getItem("role")
userObj:any=[{}]
  ngOnInit(): void {
    this.userService.GetUserByEmail(this.userEmail)
    
  }

  logindailog(){
    this.dialog.open(LoginComponent, {
      width: '333px',
      height: '455px',

    });
  
  }


  SoundDownloadedByTheUser(userID:any) {
    this.router.navigate(["users/user-sounds"])
    this.soundsService.soundsDownloadedByTheUser(userID)

  }



}
