import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-manage-sound',
  templateUrl: './user-manage-sound.component.html',
  styleUrls: ['./user-manage-sound.component.css']
})
export class UserManageSoundComponent implements OnInit {
  @ViewChild('callCreateDailog') callCreateDailog!: TemplateRef<any>
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>

  CreateForm: FormGroup=new FormGroup({
    soundName: new FormControl('',Validators.required),
    image:new FormControl('',Validators.required),
    description:new FormControl('',Validators.required),
    song:new FormControl('',Validators.required),
    userID:new FormControl('',Validators.required),

  })
  UpdateForm: FormGroup = new FormGroup({
    soundID: new FormControl('', Validators.required),
    soundName: new FormControl('', Validators.required),
    image: new FormControl(),
    description: new FormControl('', Validators.required),
    song: new FormControl(),
  })
  constructor(private router :Router,public soundService:SoundsService,public userService:UserService, public dialog:MatDialog) { }
  userEmail:any=localStorage.getItem("email");
  delete:string="assets/img/delete.png"

userObj:any=[{}]

soundObj: any = {};
isChanged=0;
soundChanged=0;
searchSound=new FormControl();

  
  ngOnInit(): void {
  }

  save(userid:any){
    this.CreateForm.value.description="--"
    this.CreateForm.value.userID= userid
    
    this.soundService.createSoundByUser(this.CreateForm.value);

    this.soundService.soundsUploadedByTheUser(userid)

  }

  opencreate(){

    this.dialog.open(this.callCreateDailog, {
      height: '330px',
      width: '300px',
    });

  }


  GetBySOUNDName(){
    this.soundService.getSoundBySoundNameForUser(this.searchSound.value)
  }


  uploadImage(file:any){
    if(file.length===0)
    return;
    this.isChanged=1;

    const uploadfile=<File>file[0];
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.soundService.uploadAttachment(formData);
  }

  uploadSong(files:any){
    if(files.length===0)
    return;
    this.soundChanged=1;

    let uploadfile=<File>files[0];
    const formData=new FormData();
    formData.append('files',uploadfile,uploadfile.name);
    this.soundService.uploadSongAttachment(formData);
  }













  openUpdateDailog(
    soundId1: any,
    soundName1: any,
    description1:any,
    categoryID1:any,

    image1:any,
    song1:any
    ) {
    this.soundObj = {
      soundID: soundId1,
      soundName: soundName1,
      description:description1,
      categoryID:categoryID1,

      image: image1,
      song:song1
    }
    this.UpdateForm.controls['soundID'].setValue(this.soundObj.soundID);


    this.dialog.open(this.callUpdateDailog, {
      height: '330px',
      width: '300px',
    });
  }



 




  update() {

    this.UpdateForm.value.description="--"

    if(this.isChanged===0 && this.soundChanged===0){ 
      this.soundService.display_Image=this.UpdateForm.value.image
      this.soundService.display_song=this.UpdateForm.value.song
      this.soundService.updateSoundsByUser(this.UpdateForm.value);
    }
    else if(this.isChanged===0 && this.soundChanged===1  ){
         this.soundService.display_Image=this.UpdateForm.value.image;
         this.soundService.updateSoundsByUser(this.UpdateForm.value);
    }
    else if(this.soundChanged===0 && this.isChanged===1){
      this.soundService.display_song=this.UpdateForm.value.song;
      this.soundService.updateSoundsByUser(this.UpdateForm.value);
    }
    else{
      this.soundService.updateSoundsByUser(this.UpdateForm.value);
    }
    
      window.location.reload();
    
      }
    

      openDeleteDailog(soundID:number)
      {
          const dialogRef=this.dialog.open(this.callDeleteDailog);
          dialogRef.afterClosed().subscribe((res)=>{
            if(res!==undefined)
            {
              if(res=='yes')
              this.soundService.delete(soundID);
              else if(res=='no')
              console.log("Thank you ");
              
            }
          })
    
    
      }
}
