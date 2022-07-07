
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SoundsService } from 'src/app/services/sounds.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-dashbourd',
  templateUrl: './user-dashbourd.component.html',
  styleUrls: ['./user-dashbourd.component.css']
})
export class UserDashbourdComponent implements OnInit {

  constructor(private router :Router, private toastr:ToastrService, public userService:UserService, private dialog:MatDialog, public soundsService:SoundsService) { }

  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  delete:string="assets/img/delete.png"

  
 userEmail:any=localStorage.getItem("email");
 logo2:string="assets/img/logo2.png";
user:any={}
isChanged:number=0

  ngOnInit(): void {

this.userService.GetUserByEmail(this.userEmail)


  }




  openUpdateDailog(
    userID1: any,userName1: any, email1: any, password1:any, phoneNumber1:any, roleID1:any,    image1:any,
    ) {
    this.user = {
      userID: userID1,
      userName: userName1,
      email:email1,
      password:password1,
      phoneNumber:phoneNumber1,
      roleID:roleID1,
      image: image1,

    }
    this.UpdateForm.controls['userID'].setValue(this.user.userID)
    this.dialog.open(this.callUpdateDailog, {
      height: '500px',
      width: '700px',
    });
  }


  UpdateForm: FormGroup = new FormGroup({
    userID: new FormControl('', Validators.required),
    userName: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
    roleID: new FormControl('', Validators.required),
    image: new FormControl(),
  })





  uploadImage(file:any){
    if(file.length===0)
    return;
    const uploadfile=<File>file[0];
    this.isChanged=1
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.userService.uploadAttachment(formData);

  }


  update() {


    this.UpdateForm.value.roleID=3;


    if(this.isChanged===0){
      this.userService.display_Image=this.UpdateForm.value.image
      this.userService.updateUsers(this.UpdateForm.value);
    }
else{
  this.userService.updateUsers(this.UpdateForm.value);
}

   window.location.reload();

  }




  logout(){
    localStorage.clear();
    this.router.navigate([""])

  }

  goToHome(){
    this.router.navigate([""])

  }

  manageSound(userID:any) {
    this.router.navigate(["users/manage-sounds"])
    this.soundsService.soundsUploadedByTheUser(userID)
    this.soundsService.AmountOfSoundsUploadedByTheUser(userID)

  }
  userReport(userID:any) {
    this.router.navigate(["users/reports"])
    this.userService.GetUserByEmail(this.userEmail)

  }

  SoundDownloadedByTheUser(userID:any) {
    this.router.navigate(["users/user-sounds"])
    this.soundsService.soundsDownloadedByTheUser(userID)

  }
}

