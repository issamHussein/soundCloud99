import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import jwt_decode from "jwt-decode";
import { Data, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountentService {
  accountent:any=[{}];
  display_Image:any;
  totalProfit:any=[{}];
  accountantSalary:any=[{}]
  totalLosses:any=[{}]

  oneAccountant:any=[{}]



  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService , private router: Router) { }




    GetAllAccountent(){
      //show spinner 
      this.spinner.show();
      //hits Api 
        this.http.get('https://localhost:44338/Accountent/GetAllAccountants').subscribe((res)=>{
        this.accountent=res;
        this.spinner.hide();
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
    }




    createAccountant(body:any){
      this.spinner.show();
      body.image=this.display_Image;
  debugger
      this.http.post('https://localhost:44338/Accountent/CreateAccountant/',body).subscribe((res)=>{
        this.spinner.hide();
        this.toastr.success('saved Successfully :)');
      },error=>{
        this.spinner.hide();
        this.toastr.error(error.status,error.message);
      })
      window.location.reload();
    }



    updateAccountent(body:any){
      body.image=this.display_Image;
  debugger
      this.http.put('https://localhost:44338/Accountent/UpdateAccountant/',body).subscribe((res)=>{
        this.toastr.success('updated Successfully :)');
    
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();
    
    }





    uploadAttachment(file:FormData){
      this.http.post('https://localhost:44338/Accountent/UploadImage/',file)
      .subscribe((res:any)=>{
        this.display_Image=res.image;
        console.log(this.display_Image);
        
        
      },err=>{
        this.toastr.error(err.status,err.message);
      })
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
  
      this.http.post('https://localhost:44338/Accountent/login',body,requestOptions)
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

        if(data.role=='admin')
        this.router.navigate(['admin/dashboard'
        ])
        else if (data.role=='customer')
        this.router.navigate(['customer/customer'])
      },err=>{
        this.router.navigate(['security/login']);
        this.toastr.error('wrong email or password ')
      })
    }
  
  
  
  





    delete(id:number){
      
      this.http.delete('https://localhost:44338/Accountent/DeleteAccountant/'+id).subscribe((res)=>{
        this.toastr.success('Deleted Successfully :)');
      },err=>{
        this.toastr.error(err.status,err.message);
      })
      window.location.reload();
  
    }
  



     GetProfitReport(body:any) {
      this.spinner.show();

      this.http.post("https://localhost:44338/Accountent/GetProfitReport",body).subscribe(res => {

     this.accountent = res;
        // this.data = this.alldata.slice(0,7);
        console.log(this.accountent);
        this.spinner.hide();
        this.toastr.success("Data Retrived");
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      });
  
    }
  

    GetTotalProfitReport(body:any) {
      this.spinner.show();
      this.http.post("https://localhost:44338/Accountent/GetSumProfitReport",body).subscribe(res => {

     this.totalProfit = res;
     
        this.spinner.hide();
        this.toastr.success("Data Retrived");
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      });}


      GetAccountantsSalary() {
        this.spinner.show();
  
        this.http.get("https://localhost:44338/Accountent/GetSalaryReport").subscribe(res => {
  
       this.accountantSalary = res;
       
          this.spinner.hide();
          this.toastr.success("Data Retrived");
        },err=>{
          this.spinner.hide();
          this.toastr.error(err.message, err.status);
        });
      }

        GetTotalLosses() {
          this.spinner.show();
    
          this.http.get("https://localhost:44338/Accountent/GetSumSalaryReport").subscribe(res => {
    
         this.totalLosses = res;
         
            this.spinner.hide();
            this.toastr.success("Data Retrived");
          },err=>{
            this.spinner.hide();
            this.toastr.error(err.message, err.status);
          });

    }
    GetAccountantByEmail(email:any){
      //show spinner 
      this.spinner.show();
      //hits Api 
      

        this.http.get('https://localhost:44338/Accountent/GetByAccountantEmail/'+email).subscribe((res)=>{
        this.oneAccountant=res;
        
        this.spinner.hide();
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
    }



    getAccountantByAccountantName(name:any){
      //show spinner 
      this.spinner.show();
      //hits Api 
      console.log(name);
        this.http.get('https://localhost:44338/Accountent/GetByAccountantName/'+name).subscribe((res)=>{
        this.accountent=res;
        this.spinner.hide();
        console.log(this.accountent);
      
        this.toastr.success('Data Retrieved !!');
      },err=>{
        this.spinner.hide();
        this.toastr.error(err.message, err.status);
      })
}
}
