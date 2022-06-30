import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AdminService } from 'src/app/services/admin.service';
import { CreateAdminComponent } from '../create-admin/create-admin.component';

@Component({
  selector: 'app-manage-admin',
  templateUrl: './manage-admin.component.html',
  styleUrls: ['./manage-admin.component.css']
})
export class ManageAdminComponent implements OnInit {
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>

  constructor(private dialog:MatDialog, public adminService:AdminService) { }
  adminObj: any = {};
isChanged:number=0;
  ngOnInit(): void {
    this.adminService.GetAllAdmin();
  }
  create()
  {
    this.dialog.open(CreateAdminComponent, {
      height: '533px',
      width: '376px',
    });
  }
  delete:string="assets/img/delete.png"


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
      height: '533px',
      width: '376px',
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



  openDeleteDailog(adminID:number)
  {
      const dialogRef=this.dialog.open(this.callDeleteDailog);
      dialogRef.afterClosed().subscribe((res)=>{
        if(res!==undefined)
        {
          if(res=='yes')
          this.adminService.delete(adminID);
          else if(res=='no')
          console.log("Thank you ");
          
        }
      })


  }













}
