import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-users',
  templateUrl: './create-users.component.html',
  styleUrls: ['./create-users.component.css']
})
export class CreateUsersComponent implements OnInit {
  CreateForm: FormGroup=new FormGroup({
    userName: new FormControl('',Validators.required),
    email: new FormControl('',[Validators.required , Validators.email]),
    password: new FormControl('',[Validators.required , Validators.minLength(8)]),
    phoneNumber: new FormControl(),
    roleID: new FormControl('',Validators.required),
    image:new FormControl(),
  })
  constructor(private user:UserService) { }

  ngOnInit(): void {
  }
  save(){
    this.CreateForm.value.roleID=3
    this.user.createUser(this.CreateForm.value);
  }


  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.user.uploadAttachment(formData);
  }



}
