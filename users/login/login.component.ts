import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  delete:string="assets/img/delete.png"
  
  email = new FormControl();

  // email = new FormControl('',[Validators.required,Validators.email]);
  // password=new FormControl('',[Validators.required,Validators.minLength(8)]);
  password=new FormControl();

  constructor(private dialog:MatDialog,public userService:UserService, private router:Router, private spinner: NgxSpinnerService,private tostar:ToastrService) { }
  current:number=0;
 ngOnInit(): void {
  }


  
submit(){

  this.userService.submit(this.email,this.password);
  if(localStorage.getItem('token')){
    this.dialog.closeAll()

  }


}
  goToRegister(){
    this.dialog.closeAll()
    this.dialog.open(RegisterComponent,{
      width: '350px',
      height: '500px',

    });
  }
}
