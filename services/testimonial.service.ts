import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class TestimonialService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router) { }
    data:any=[{}];
    display_Image:any;


    GetAllTestimonial(){
      //show spinner 
      this.spinner.show();
      //hits Api 
        this.http.get('https://localhost:44338/Testimonial/GetAllTestimonial/').subscribe((res)=>{
        this.data=res;
        console.log(this.data);
        
        this.spinner.hide();
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
  
    }


    CreateTestimonial(body:any){

      this.spinner.show();
  
      this.http.post('https://localhost:44338/Testimonial/CreateTestimonial/',body).subscribe((res)=>{
     
        this.spinner.hide();
        this.toastr.success('saved Successfully :)');
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.status,error.message);
      })
      window.location.reload();
    }

    
  



    UpdateTestimonial(body:any){
      body.testImage=this.display_Image;
      
      this.http.put('https://localhost:44338/Testimonial/UpdateTestimonial/',body).subscribe((res)=>{
        this.toastr.success('updated Successfully :)');
  
      },err=>{
        this.toastr.error(err.status,err.message);
      })
  
    }

    DeleteTestimonial(id:number){
      this.http.delete('https://localhost:44338/Testimonial/DeleteTestimonial/'+id).subscribe((res)=>{
        this.toastr.success('Deleted Successfully :)');
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();

    }

}
