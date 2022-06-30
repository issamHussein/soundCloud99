import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HomeService } from 'src/app/services/home.service';
import { SoundsService } from 'src/app/services/sounds.service';

@Component({
  selector: 'app-create-sound',
  templateUrl: './create-sound.component.html',
  styleUrls: ['./create-sound.component.css']
})
export class CreateSoundComponent implements OnInit {
  CreateForm: FormGroup=new FormGroup({
    soundName: new FormControl('',Validators.required),
    image:new FormControl('',Validators.required),
    description:new FormControl(),
    publishDate:new FormControl('',Validators.required),
    categoryID:new FormControl('',Validators.required),
    song:new FormControl('',Validators.required),
  })
  constructor(private sound:SoundsService) { }
  delete:string="assets/img/delete.png"

  ngOnInit(): void {
  }
  save(){

this.CreateForm.value.description="--"
    this.sound.createSound(this.CreateForm.value);
    window.location.reload();

  }






  uploadImage(file:any){
    if(file.length===0)
    return;
    let uploadfile=<File>file[0];
 
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.sound.uploadAttachment(formData);
  }

  uploadSong(files:any){
    if(files.length===0)
    return;
    let uploadfile=<File>files[0];
 
    const formData=new FormData();
    formData.append('files',uploadfile,uploadfile.name);
    this.sound.uploadSongAttachment(formData);
  }
}
