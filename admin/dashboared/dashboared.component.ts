import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-dashboared',
  templateUrl: './dashboared.component.html',
  styleUrls: ['./dashboared.component.css']
})
export class DashboaredComponent implements OnInit {
  admin:string="assets/img/Admin.png"
  logo:string="assets/img/logo.png"
  logo2:string="assets/img/logo2.png"

  delete:string="assets/img/delete.png"

  constructor(private router :Router, private toastr:ToastrService,public adminService:AdminService,private dialog:MatDialog) { }
  userEmail:any=localStorage.getItem("email");
  adminObj:any={}
  isChanged:number=0
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>

  ngOnInit(): void {
    console.log(this.userEmail);
    
    this.adminService.GetAdminByEmail(this.userEmail)

  }











  UpdateForm: FormGroup = new FormGroup({
    adminID: new FormControl('', Validators.required),
    adminName: new FormControl('',Validators.required),
    image:new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required , Validators.email]),
    roleID:new FormControl('',Validators.required),
    password:new FormControl('',[Validators.required ,Validators.minLength(8)])
  })

  openUpdateDailog(
    AdminID1: any,AdminName1: any, Email1: any, Password:any, roleID1:any,    image1:any,
    ) {
    this.adminObj = {
      adminID: AdminID1,
      adminName: AdminName1,
      email:Email1,
      password:Password,
      roleID:roleID1,
      image: image1,

    }
    this.UpdateForm.controls['adminID'].setValue(this.adminObj.adminID)
    this.dialog.open(this.callUpdateDailog, {
      height: '500px',
      width: '700px',
    });
  }



  uploadImage(file:any){
    if(file.length===0)
    return;
    this.isChanged=1
    const uploadfile=<File>file[0];
    // {
    //   file[0]:'photo1.png',
    // }
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.adminService.uploadAttachment(formData);
  }



  update() {

    this.UpdateForm.value.roleID=1
    if(this.isChanged===0){
      this.adminService.display_Image=this.UpdateForm.value.image
      this.adminService.updateAdmin(this.UpdateForm.value);
    }
else{
  this.adminService.updateAdmin(this.UpdateForm.value);
}



  }

















  logout(){
    localStorage.clear();
    this.router.navigate(['admin-login'])

  }


  managecat(){
    this.router.navigate(['admin/manage-cat'])
      
  }
  managehome(){
    this.router.navigate(['admin/manage-home'])
      
  }
  manageusers(){
    this.router.navigate(['admin/manage-users'])
      
  }
  managesound(){
    this.router.navigate(['admin/manage-sound'])
      
  }
  manageaccountant(){
    this.router.navigate(['admin/manage-accountant'])
      
  }
  manageaboutus(){
    this.router.navigate(['admin/manage-aboutus'])
      
  }
  managetestimonial(){
    this.router.navigate(['admin/manage-testimonial'])
      
  }

  goToHome(){
    this.router.navigate([""])

  }
  manageContactAs(){
    this.router.navigate(['admin/manage-contact'])
      
  }
  Report(){
    this.router.navigate(['admin/finantial-report'])
      
  }
  manageAdmin(){
    this.router.navigate(['admin/manage-admin'])
      
  }

  Top10(){
    this.router.navigate(['admin/topten'])

  }


  manageAlbums(){
    this.router.navigate(['admin/manage-albums'])
      
  }

  manageUserAlbums(){
    this.router.navigate(['admin/manage-user-albums'])
      
  }

}
