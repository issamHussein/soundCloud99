import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { WelcomService } from 'src/app/services/welcom.service';

@Component({
  selector: 'app-create-welcom',
  templateUrl: './create-welcom.component.html',
  styleUrls: ['./create-welcom.component.css']
})
export class CreateWelcomComponent implements OnInit {

  constructor(private welcomService:WelcomService) { }

  ngOnInit(): void {
  }

  delete:string="assets/img/delete.png"

  CreateForm: FormGroup=new FormGroup({
    Description: new FormControl('',Validators.required),
    text: new FormControl(),
    text2: new FormControl(),
    image1:new FormControl('',Validators.required),
  })
  




  save(){
    
    this.welcomService.createHome(this.CreateForm.value);
    window.location.reload();

  }



  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.welcomService.uploadAttachment(formData);
  }












}
