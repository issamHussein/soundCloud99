import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HomeService {
  // message:string='Welcome in our Training Site :) ';
  selectedCategory:any={};
  // numberofActiveCourse =new BehaviorSubject(0);
  library:any=[{}];
  searchData:any[]=[]

  display_Image:any;
  // books:any=[];
  selectedCat:any={};

  constructor(private http:HttpClient,
     private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router ) { }

     getSoundByCategoryName(name:any){
      this.spinner.show();
      console.log(name);
        this.http.get('https://localhost:44338/Category/GetByCATEGORYName/'+name).subscribe((res)=>{
        this.library=res;
        this.spinner.hide();
        console.log(this.library);
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
    }
    
  GetAllCATEGORY(){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Category/GetAllCATEGORY/').subscribe((res)=>{
      this.library=res;
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })

  }
  
  createCat(body:any){

    this.spinner.show();
    body.image=this.display_Image;


    this.http.post('https://localhost:44338/Category/CreateCATEGORY/',body).subscribe((res)=>{
   
      this.spinner.hide();
      this.toastr.success('saved Successfully :)');
    },error=>{
      this.spinner.hide();
      this.toastr.error(error.status,error.message);
    })
    window.location.reload();
  }

  uploadAttachment(file:FormData){
    
    this.http.post('https://localhost:44338/Category/UploadImage/',file)
    .subscribe((res:any)=>{
      this.display_Image=res.image;
      
    },err=>{
      this.toastr.error(err.status,err.message);
    })
  }



  updateCategory(body:any){
    body.image=this.display_Image;
    
    this.http.put('https://localhost:44338/Category/UpdateCATEGORY/',body).subscribe((res)=>{
      this.toastr.success('updated Successfully :)');

    },err=>{
      this.toastr.error(err.status,err.message);
    })

  }

    delete(id:number){
      this.http.delete('https://localhost:44338/Category/DeleteCATEGORY/'+id).subscribe((res)=>{
        this.toastr.success('Deleted Successfully :)');
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();

    }
    searchCourse(library:any)
    {
      
      this.http.post('https://localhost:44338/Category/GetByCATEGORYName',library)
      .subscribe((res)=>{
        console.log(res);
        
        this.library=[res];
        
      },err=>{
        this.toastr.error('something error');
      })
    }



  }