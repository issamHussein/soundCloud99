import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { SoundsService } from './sounds.service';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router, public soundService:SoundsService) { }
    data:any=[{}];

    purchase(body:any){
      console.log(body);     
      this.spinner.show(); 
      
        this.http.post('https://localhost:44338/purchase/purchases/',body).subscribe((res)=>{
        this.data=res;

if (this.data=res) {
  this.spinner.hide();
  
  this.toastr.success('bought successfully');

} else {
  this.spinner.hide();
  this.toastr.error('wrong information or there is not enough balance');
}



      },err=>{
        this.spinner.hide();
        this.toastr.error("wrong information or there is not enough balance");
      })
   }


buySound(body:any){
  this.spinner.show();
  
  
  this.http.post('https://localhost:44338/Sounds/buySound',body).subscribe((res)=>{
    
  this.spinner.hide();
    this.toastr.success('bought Successfully :)');
  },error=>{
    this.spinner.hide();
    this.toastr.error(error.status,error.message);
  })
}

   
}
