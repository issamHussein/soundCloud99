import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class LikeService {
 like:any=[{}];
amtOfLikes:any=[{}]
  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router) { }



    createLikes(body:any){

      this.spinner.show();
      this.http.post('https://localhost:44338/Likes/CreateLikes/',body).subscribe((res)=>{
     

      if (res==true) {
        this.spinner.hide();
        this.toastr.success('Liked Successfully :)');
      } else {
        this.spinner.hide();
        this.toastr.warning('Like Removed :(');
      }
        
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.status,error.message);
      })
      // window.location.reload();
    }


    // deleteLikes(id:number){
    //   this.http.delete('https://localhost:44338/Likes/DeleteLike/'+id).subscribe((res)=>{
    //     this.toastr.success('remove like');
    //   },err=>{
    //     this.toastr.error(err.status,err.message);
    //   })
    //   window.location.reload();
    
    // }


    getLikesBySoundId()
    {
      
      //show spinner 
      // this.spinner.show();
      //hits Api 
        this.http.get('https://localhost:44338/Likes/GetAmountOfLikes').subscribe((res)=>{
        this.amtOfLikes=res;
        // this.spinner.hide();
        // this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
    }
    






}
