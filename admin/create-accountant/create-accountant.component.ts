import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountentService } from 'src/app/services/accountent.service';

@Component({
  selector: 'app-create-accountant',
  templateUrl: './create-accountant.component.html',
  styleUrls: ['./create-accountant.component.css']
})
export class CreateAccountantComponent implements OnInit {
  CreateForm: FormGroup=new FormGroup({
    accountantName: new FormControl('',Validators.required),
    salary:new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required , Validators.email]),
    roleID:new FormControl('',Validators.required),
    password:new FormControl('',[Validators.required ,Validators.minLength(8)]),
    image:new FormControl('',Validators.required),

  })
  delete:string="assets/img/delete.png"
  constructor(private accountant:AccountentService) { }

  ngOnInit(): void {
  }
  save(){
    this.CreateForm.value.roleID=2
    this.accountant.createAccountant(this.CreateForm.value);
    
  }

  uploadImage(file:any){
    console.log(file);
    
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.accountant.uploadAttachment(formData);
  }



}
