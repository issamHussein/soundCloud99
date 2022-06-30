import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CommentsService } from 'src/app/services/comments.service';
import { LikeService } from 'src/app/services/like.service';
import { PaymentService } from 'src/app/services/payment.service';
import { SoundsService } from 'src/app/services/sounds.service';
import { UserService } from 'src/app/services/user.service';
import { LoginComponent } from 'src/app/users/login/login.component';

@Component({
  selector: 'app-top10',
  templateUrl: './top10.component.html',
  styleUrls: ['./top10.component.css']
})
export class Top10Component implements OnInit {
  @ViewChild('mainDialog') mainDialog!: TemplateRef<any>
  @ViewChild('boughtSounds') boughtSounds!: TemplateRef<any>
  @ViewChild('buySongDialog') buySongDialog!: TemplateRef<any>
  @ViewChild('visaPayment') visaPayment!: TemplateRef<any>

  constructor(public paymentService:PaymentService,public likes:LikeService,public userService:UserService,private dialog:MatDialog,public commentsService:CommentsService,public top10Service:SoundsService, private router:Router) { }
  body:any={
    SoundID:0,
    UserID:0
    }
    userEmail:any=localStorage.getItem("email");
    delete:string="assets/img/delete.png"

  ngOnInit(): void {
this.top10Service.GetTop10Sounds()
this.userService.GetUserByEmail(this.userEmail)

  }
  freeSoundForm:FormGroup=new FormGroup({
    SoundID:new FormControl('',[Validators.required]),  
    UserID:  new FormControl('',[Validators.required]), 
  
  })
  

  paymentForm:FormGroup=new FormGroup({
    CCV:new FormControl('',[Validators.required]),
    VisaID:new FormControl('',Validators.required),
    ExpireDate:new FormControl('',[Validators.required]) ,    
    SoundID:new FormControl('',[Validators.required]),  
    UserID:  new FormControl('',[Validators.required]), 
    Expiredyear:  new FormControl('',[Validators.required]), 
  });
  CreateForm: FormGroup=new FormGroup({
    text: new FormControl('',Validators.required),
    soundID:new FormControl('',Validators.required),
    userID:new FormControl('',Validators.required)
  
  })
  getAllSounds(){
    this.router.navigate(["sounds"])
    this.top10Service.GetAllSounds()
  }
  userRole:any=localStorage.getItem("role")



  openMainDialog(soundID:any, userID:any=0){
    console.log(soundID);
    console.log(userID);
  
    this.body.SoundID=soundID
    this.body.UserID=userID
  
    if (userID==0) {
        this.dialog.open(LoginComponent);
    } else {
      this.dialog.open(this.mainDialog);
     this.top10Service.getSoundBySoundId(soundID)
     this.top10Service.check(this.body)
  
    }
  
     
  }


  like(soundID:any, userID:any){
    console.log(soundID,userID );
    
    this.body.SoundID=soundID
    this.body.UserID=userID
   
      this.likes.createLikes(this.body)
   
     }

     openListenDialog(){
      console.log("thank you");
      this.dialog.open(this.boughtSounds,{
        height: '492px',
      });
      }



      openBuySongDaialog(price:any,soundID:any, userID:any ){
        console.log(price,soundID,userID );
        
         if (price==0) {
           console.log("im freeeeee");
           
          this.freeSoundForm.value.SoundID=soundID
          this.freeSoundForm.value.UserID=userID
             this.paymentService.buySound(this.freeSoundForm.value);
           this.dialog.open(this.boughtSounds,{
            height: '492px',
          });
         } else {
          this.dialog.open(this.visaPayment,{
            height: '492px',
          });
         }
        }
      buysong(soundID:any, userID:any){
        this.paymentForm.value.SoundID=soundID
        this.paymentForm.value.UserID=userID
           this.paymentService.purchase(this.paymentForm.value)
           this.dialog.closeAll();
        }
        save(userID:any, SoundID:any){
          console.log(SoundID);
          console.log(userID);
          
          this.CreateForm.value.userID=userID
          this.CreateForm.value.soundID=SoundID
          this.commentsService.createComments(this.CreateForm.value);
        
        }
        openLogin(){
          this.dialog.open(LoginComponent);          
        }
}


