import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AboutUsService } from 'src/app/services/about-us.service';

@Component({
  selector: 'app-create-aboutus',
  templateUrl: './create-aboutus.component.html',
  styleUrls: ['./create-aboutus.component.css']
})
export class CreateAboutusComponent implements OnInit {

  constructor(private about:AboutUsService) { }
  delete:string="assets/img/delete.png"


  ngOnInit(): void {
  }

  CreateForm: FormGroup=new FormGroup({
    description: new FormControl('',Validators.required),
    image:new FormControl(),
    email:new FormControl('',[Validators.required , Validators.email]),
    phonenumber: new FormControl('',Validators.required),
    location: new FormControl('',Validators.required),

  })
  




  save(){
    this.about.createAboutUs(this.CreateForm.value);
    window.location.reload();

  }



  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.about.uploadAttachment(formData);
  }




}
