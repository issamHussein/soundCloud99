import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ContactUsService {
  data:any=[{}];

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router ) { }





    GetAllContact(){
      //show spinner 

      this.spinner.show();
      //hits Api 
        this.http.get('https://localhost:44338/ContactUs/GetAllContactUs').subscribe((res)=>{
        this.data=res;
        console.log(this.data);
        
        this.spinner.hide();
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })

    }




    createContactus(body:any){

      this.spinner.show();
      // body.image1=this.display_Image;
  
  
      this.http.post('https://localhost:44338/ContactUs/CreateContactUs/',body).subscribe((res)=>{
     
        this.spinner.hide();
        this.toastr.success('thanks :)');
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.status,error.message);
      })
      window.location.reload();
    }




    delete(id:number){
      
      this.http.delete('https://localhost:44338/ContactUs/DeleteContactUs/'+id).subscribe((res)=>{
        this.toastr.success('Deleted Successfully :)');
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();
  
    }



}
