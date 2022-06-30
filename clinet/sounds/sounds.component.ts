import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { SoundsService } from 'src/app/services/sounds.service';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/services/home.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LikeService } from 'src/app/services/like.service';
import { UserService } from 'src/app/services/user.service';
import { PaymentService } from 'src/app/services/payment.service';
import { CommentsService } from 'src/app/services/comments.service';
@Component({
  selector: 'app-sounds',
  templateUrl: './sounds.component.html',
  styleUrls: ['./sounds.component.css']
})
export class SoundsComponent implements OnInit {
 
  @ViewChild('mainDialog') mainDialog!: TemplateRef<any>
  @ViewChild('boughtSounds') boughtSounds!: TemplateRef<any>
  @ViewChild('buySongDialog') buySongDialog!: TemplateRef<any>
  @ViewChild('visaPayment') visaPayment!: TemplateRef<any>
  @ViewChild('commentDialog') commentDialog!: TemplateRef<any>

// contantList:any
// checkSameValue:any
searchSound=new FormControl();

  constructor(public commentsService:CommentsService,private toastr:ToastrService, private router:Router, public sounds:SoundsService, private dialog:MatDialog, public likes:LikeService, public userService:UserService, public paymentService:PaymentService) { }
  delete:string="assets/img/delete.png"

numOfLikes:number=0;
body:any={
SoundID:0,
UserID:0
}
downloadIdObj:number=this.sounds.downloadedSound.downloadID;
userObj:any={}
soundObj:any={}
userEmail:any=localStorage.getItem("email");



paymentForm:FormGroup=new FormGroup({
  CCV:new FormControl('',[Validators.required]),
  VisaID:new FormControl('',Validators.required),
  ExpireDate:new FormControl('',[Validators.required]) ,    
  SoundID:new FormControl('',[Validators.required]),  
  UserID:  new FormControl('',[Validators.required]), 
  Expiredyear:  new FormControl('',[Validators.required]), 
  
});

freeSoundForm:FormGroup=new FormGroup({
  SoundID:new FormControl('',[Validators.required]),  
  UserID:  new FormControl('',[Validators.required]), 

})




CreateForm: FormGroup=new FormGroup({
  text: new FormControl('',Validators.required),
  soundID:new FormControl('',Validators.required),
  userID:new FormControl('',Validators.required)

})





  ngOnInit(): void {
   this.likes.getLikesBySoundId()
   this.userService.GetUserByEmail(this.userEmail)
   
  }


  like(soundID:any, userID:any){
 this.body.SoundID=soundID
 this.body.UserID=userID

   this.likes.createLikes(this.body)

  }




 





openMainDialog(soundID:any, userID:any){

  this.body.SoundID=soundID
  this.body.UserID=userID

console.log(soundID);
console.log(userID);

   this.dialog.open(this.mainDialog);
   this.sounds.getSoundBySoundId(soundID)

   this.sounds.check(this.body)

}






openListenDialog(){
this.dialog.open(this.boughtSounds);
}





buysong(soundID:any, userID:any){
  this.paymentForm.value.SoundID=soundID
  this.paymentForm.value.UserID=userID
     this.paymentService.purchase(this.paymentForm.value);
     this.dialog.closeAll();
  }




openBuySongDaialog(price:any,soundID:any, userID:any ){
console.log(price,soundID,userID );

 if (price==0) {
   console.log("im freeeeee");
   
  this.freeSoundForm.value.SoundID=soundID
  this.freeSoundForm.value.UserID=userID
     this.paymentService.buySound(this.freeSoundForm.value);
   this.dialog.open(this.boughtSounds);
 }
 
 else {
  this.dialog.open(this.visaPayment,{
    height: '474px',
  });
 }

}










returnSound(){

}





openCommentDialog(SoundID:any){



  this.dialog.open(this.commentDialog);
  this.sounds.getSoundBySoundId(SoundID)
  this.userService.GetUserByEmail(this.userEmail)
  this.commentsService.GetAllComments(SoundID)

}



save(userID:any, SoundID:any){
  console.log(SoundID);
  console.log(userID);
  
  this.CreateForm.value.userID=userID
  this.CreateForm.value.soundID=SoundID
  this.commentsService.createComments(this.CreateForm.value);
  this.dialog.closeAll();

}

GetBySOUNDName(){
  this.sounds.getSoundBySoundName(this.searchSound.value)
}



logout(){
  localStorage.clear();
  this.router.navigate([""])

}
}


