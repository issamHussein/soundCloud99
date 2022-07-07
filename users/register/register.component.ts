import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  delete:string="assets/img/delete.png"

  constructor(private dialog:MatDialog,public userService:UserService, private router:Router, private spinner: NgxSpinnerService,private tostar:ToastrService) { }

  ngOnInit(): void {
  }

  CreateForm: FormGroup=new FormGroup({
    userName: new FormControl('',Validators.required),
    email: new FormControl('',[Validators.required , Validators.email]),
    password: new FormControl('',[Validators.required , Validators.minLength(8)]),
    phoneNumber: new FormControl(),
    roleID: new FormControl('',Validators.required),
    image:new FormControl(),
  })

  
submit(){
  this.CreateForm.value.roleID=3
  // this.userService.submit();
  if(localStorage.getItem('token'))
  this.router.navigate(['']);
  this.userService.createUser(this.CreateForm.value);


}
  goToLogin(){
    this.dialog.closeAll()
    this.dialog.open(LoginComponent, {
      width: '333px',
      height: '455px',

    });
  }



  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.userService.uploadAttachment(formData);
  }



}
