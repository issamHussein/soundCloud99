import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-create-admin',
  templateUrl: './create-admin.component.html',
  styleUrls: ['./create-admin.component.css']
})
export class CreateAdminComponent implements OnInit {
  CreateForm: FormGroup=new FormGroup({
    AdminName: new FormControl('',Validators.required),
    image:new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required , Validators.email]),
    roleID:new FormControl('',Validators.required),
    Password:new FormControl('',[Validators.required ,Validators.minLength(8)])
  })

  constructor(public adminService:AdminService) { }
  delete:string="assets/img/delete.png"
  ngOnInit(): void {
  }
  save(){
    this.CreateForm.value.roleID=1
    this.adminService.createAdmin(this.CreateForm.value);
  }

  uploadImage(file:any){
    console.log(file);
    
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.adminService.uploadAttachment(formData);
  }

}
