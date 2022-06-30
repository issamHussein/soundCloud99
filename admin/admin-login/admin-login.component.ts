import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {
  email = new FormControl('',[Validators.required,Validators.email]);
   password=new FormControl('',[Validators.required,Validators.minLength(8)]);

  constructor(public adminService:AdminService,private router:Router, private spinner: NgxSpinnerService,private tostar:ToastrService) { }

  ngOnInit(): void {
  }



  submit(){
    this.adminService.submit(this.email,this.password);
    if(localStorage.getItem('token'))
    { this.router.navigate(['admin/dashbourd'])
  }
  
  }
  
    goToRegister(){
      this.spinner.show();
      this.router.navigate(['security/register'])
      this.spinner.hide();
    }






}
