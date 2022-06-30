import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-create-cat',
  templateUrl: './create-cat.component.html',
  styleUrls: ['./create-cat.component.css']
})
export class CreateCatComponent implements OnInit {
  CreateForm: FormGroup=new FormGroup({
  categoryName: new FormControl('',Validators.required),
  image:new FormControl('',Validators.required)
})
  constructor(private home:HomeService) { }
  delete:string="assets/img/delete.png"

  ngOnInit(): void {
  }
  save(){
    this.home.createCat(this.CreateForm.value);
    window.location.reload();

  }

  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.home.uploadAttachment(formData);
  }

}
