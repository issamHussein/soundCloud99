import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router) { }
    display_Image:any;

data:any=[{}]



GetAllComments(id:number){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Comments/GetAllComments/'+id).subscribe((res)=>{
      this.data=res;
      console.log(this.data);
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })
    //hide spinner
    //res --> show toastr
 }

 createComments(body:any){
  this.spinner.show();
  
  
  this.http.post('https://localhost:44338/Comments/CreateComments',body).subscribe((res)=>{
    
  this.spinner.hide();
    this.toastr.success('comment Successfully :)');
  },error=>{
    this.spinner.hide();
    this.toastr.error(error.status,error.message);
  })

}

}
