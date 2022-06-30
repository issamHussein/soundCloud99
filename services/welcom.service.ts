import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class WelcomService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router) { }

    data:any=[{}];
    display_Image:any;


    GetAllHome(){
      //show spinner 

      this.spinner.show();
      //hits Api 
        this.http.get('https://localhost:44338/HomePage/GetAllHomePage').subscribe((res)=>{
        this.data=res;
        console.log(this.data);
        
        this.spinner.hide();
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })

    }
  




    createHome(body:any){

      this.spinner.show();
      body.image1=this.display_Image;
  debugger
  
      this.http.post('https://localhost:44338/HomePage/CreateHomePage/',body).subscribe((res)=>{
     
        this.spinner.hide();
        this.toastr.success('saved Successfully :)');
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.status,error.message);
      })
      window.location.reload();
    }

    uploadAttachment(file:FormData){
      
      this.http.post('https://localhost:44338/HomePage/UploadImage/',file)
      .subscribe((res:any)=>{
        this.display_Image=res.image1;
        console.log(this.display_Image);
        
      },err=>{
        this.toastr.error(err.status,err.message);
      })
    }
  
    updateHome(body:any){
      body.image1=this.display_Image;
      debugger
      this.http.put('https://localhost:44338/HomePage/UpdateHomePage/',body).subscribe((res)=>{
        this.toastr.success('updated Successfully :)');
  
      },err=>{
        this.toastr.error(err.status,err.message);
      })
  
    }



    delete(id:number){
      debugger
      this.http.delete('https://localhost:44338/HomePage/DeleteHomePage/'+id).subscribe((res)=>{
        this.toastr.success('Deleted Successfully :)');
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();
  
    }





}
