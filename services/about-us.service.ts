import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AboutUsService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router ) { }
    data:any=[{}];
    display_Image:any;




  GetAllAboutUs(){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/AboutUs/GetAllAboutUs/').subscribe((res)=>{
      this.data=res;
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })

  }


  createAboutUs(body:any){

    this.spinner.show();
    body.image=this.display_Image;

debugger
    this.http.post('https://localhost:44338/AboutUs/CreateAboutUs/',body).subscribe((res)=>{
   debugger
      this.spinner.hide();
      this.toastr.success('saved Successfully :)');
    },error=>{
      this.spinner.hide();
      this.toastr.error(error.status,error.message);
    })
    window.location.reload();
  }







  uploadAttachment(file:FormData){
    
    this.http.post('https://localhost:44338/AboutUs/UploadImage/',file)
    .subscribe((res:any)=>{
      this.display_Image=res.image;
    },err=>{
      this.toastr.error(err.status,err.message);
    })
  }



  updateAboutUs(body:any){
    body.image=this.display_Image;
    
    this.http.put('https://localhost:44338/AboutUs/UpdateAboutUs/',body).subscribe((res)=>{
      this.toastr.success('updated Successfully :)');

    },err=>{
      this.toastr.error(err.status,err.message);
    })

  }


  delete(id:number){
    this.http.delete('https://localhost:44338/AboutUs/DeleteAboutUs/'+id).subscribe((res)=>{
      this.toastr.success('Deleted Successfully :)');
    },err=>{
      this.toastr.error(err.status,err.message);
    })
    window.location.reload();

  }






}
