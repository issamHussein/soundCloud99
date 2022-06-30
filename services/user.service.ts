import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Input } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import jwt_decode from "jwt-decode";
import { MatDialog } from '@angular/material/dialog';


@Injectable({
  providedIn: 'root'
})
export class UserService {

 



  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router,private dialog:MatDialog) { }

  user:any=[{}];
  oneUser:any=[{}]
  display_Image:any;
profit:any=[{}]
totalProfit:any=[{}]
userHome:any=[{}]
id:number=0
searchUser:any=[{}]

  GetAllUsers(){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Users/GetAllUsers').subscribe((res)=>{
      this.user=res;
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })
  }



  createUser(body:any){
    this.spinner.show();
    body.image=this.display_Image;
    
    
    this.http.post('https://localhost:44338/Users/CreateUsers/',body).subscribe((res)=>{
      this.spinner.hide();
      this.toastr.success('saved Successfully :)');
    },error=>{
      this.spinner.hide();
      this.toastr.error(error.status,error.message);
    })
  }



  updateUsers(body:any){
    body.image=this.display_Image;
    
    this.http.put('https://localhost:44338/Users/UpdateUsers/',body).subscribe((res)=>{
      this.toastr.success('updated Successfully :)');
  
    },err=>{
      this.toastr.error(err.status,err.message);
    })
    window.location.reload();
  
  }

  uploadAttachment(file:FormData){
    this.http.post('https://localhost:44338/Users/UploadImage/',file)
    .subscribe((res:any)=>{
      this.display_Image=res.image;
      console.log(this.display_Image);
      
      
    },err=>{
      this.toastr.error(err.status,err.message);
    })
  }
  
  delete(id:number){
    this.http.delete('https://localhost:44338/Users/DeleteUsers/'+id).subscribe((res)=>{
      this.toastr.success('Deleted Successfully :)');
    },err=>{
      this.toastr.error(err.status,err.message);
    })
    window.location.reload();
  
  }





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
    ;
    this.http.post('https://localhost:44338/Users/login',body,requestOptions)
    .subscribe((res:any)=>{
      console.log(res);
     // res=res.toString()
      const responce ={
        token:res.toString()
        
      }
      this.toastr.success('login successfully !!');

      localStorage.setItem('token', responce.token);
      let data:any= jwt_decode(responce.token);

       localStorage.setItem('user',JSON.stringify({...data}));
       localStorage.setItem('email', data.email);
       localStorage.setItem('role', data.role);
       this.dialog.closeAll()
window.location.reload()

      if (data.role=='acountant')
      this.router.navigate(['acountant/acountant'])
    },err=>{
      this.router.navigate(['security/login']);
      this.toastr.error('wrong email or password ')
    })
  }



  GetUserByEmail(email:any):object{
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Users/GetByUserEmail/'+email).subscribe((res)=>{
      this.user=res;
      console.log(this.user);
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();

      this.toastr.error(err.message, err.status);

    })
    return this.user
  }


  GetUserByEmailForHome(email:any){
    //show spinner 
    this.spinner.show();
    //hits Api 
      this.http.get('https://localhost:44338/Users/GetByUserEmail/'+email).subscribe((res)=>{
      this.userHome=res;
      console.log(this.user);
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();

      this.toastr.error(err.message, err.status);

    })
  }

////////////////////////////////////////////


GetProfitReport(body:any) {
  this.spinner.show();

  this.http.post("https://localhost:44338/Users/GetProfitReport",body).subscribe(res => {

 this.profit = res;
 
    // this.data = this.alldata.slice(0,7);
    console.log(this.profit);
    this.spinner.hide();
    this.toastr.success("Data Retrived");
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  });

}


GetTotalProfitReport(body:any) {
  this.spinner.show();

  this.http.post("https://localhost:44338/Users/GetSumProfitReport",body).subscribe(res => {

 this.totalProfit = res;
 console.log(this.totalProfit);
 
    this.spinner.hide();
    this.toastr.success("Data Retrived");
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  });}





  GetUserIDByEmail(email:any){
    //show spinner 
    this.spinner.show();
    //hits Api 
    
      this.http.get('https://localhost:44338/Users/GetIdByUserEmail/'+email).subscribe((res)=>{
      this.oneUser=res;
      
      this.spinner.hide();
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();

      this.toastr.error(err.message, err.status);

    })
   

  }




  getUserByUserName(name:any){
    //show spinner 
    this.spinner.show();
    //hits Api 
    console.log(name);
      this.http.get('https://localhost:44338/Users/GetByUserName/'+name).subscribe((res)=>{
      this.user=res;
      this.spinner.hide();
      console.log(this.searchUser);
    
      this.toastr.success('Data Retrieved !!');
    },err=>{
      this.spinner.hide();
      this.toastr.error(err.message, err.status);
    })
  }






























  }
