import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Input } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router) { }

    display_Image:any;
data:any=[{}]
oneAdmin:any=[{}]

  submit(email:any, password:any){
    var body ={
      email:email.value.toString(),
      password:password.value.toString()
    }
    const headerDir={
      'Content-Type':'application/json',
      'Accept':'application/json'
    }
    const requestOptions={
      headers:new HttpHeaders(headerDir)
    }
    this.http.post('https://localhost:44338/Admin/login',body,requestOptions)
    .subscribe((res:any)=>{
      console.log(res);
     // res=res.toString()
      const responce ={
        token:res.toString()
      }
      
      localStorage.setItem('token', responce.token);
      let data:any= jwt_decode(responce.token);

       localStorage.setItem('user',JSON.stringify({...data}))
       localStorage.setItem('email', data.email);
       localStorage.setItem('role', data.role);
      if (data.role=='admin')
      this.router.navigate(['admin/manage-aboutus'])
    },err=>{
      this.router.navigate(['security/login']);
      this.toastr.error('wrong email or password ')
    })
  }


  GetAllAdmin(){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Admin/GetAllAdmin').subscribe((res)=>{
      this.data=res;
      console.log(this.data);
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })
  }




  createAdmin(body:any){
    this.spinner.show();
    body.image=this.display_Image;
    debugger
    this.http.post('https://localhost:44338/Admin/CreateAdmin/',body).subscribe((res)=>{
      this.spinner.hide();
      this.toastr.success('saved Successfully :)');
    },error=>{
      this.spinner.hide();
      this.toastr.error(error.status,error.message);
    })
    window.location.reload()
  }



  updateAdmin(body:any){
    body.image=this.display_Image;
    this.http.put('https://localhost:44338/Admin/UpdateAdmin/',body).subscribe((res)=>{
      this.toastr.success('updated Successfully :)');
  
    },err=>{
      this.toastr.error(err.status,err.message);
    })
    window.location.reload();
  
  }





  uploadAttachment(file:FormData){
    console.log(file);
    
    this.http.post('https://localhost:44338/Admin/UploadImage/',file)
    .subscribe((res:any)=>{
      this.display_Image=res.image;
      console.log(this.display_Image);
      
      
    },err=>{
      this.toastr.error(err.status,err.message);
    })
  }


  delete(id:number){
    debugger
    this.http.delete('https://localhost:44338/Admin/DeleteAdmin/'+id).subscribe((res)=>{
      this.toastr.success('Deleted Successfully :)');
    },err=>{
      this.toastr.error(err.status,err.message);
    })
    window.location.reload();

  }


 GetAdminByEmail(email:any){
    //show spinner 
    this.spinner.show();
    //hits Api 
    
      this.http.get('https://localhost:44338/Admin/GetByAdminEmail/'+email).subscribe((res)=>{
      this.oneAdmin=res;
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })
  }


}
