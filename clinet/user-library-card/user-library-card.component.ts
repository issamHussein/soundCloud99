import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/services/home.service';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { UserService } from 'src/app/services/user.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-user-library-card',
  templateUrl: './user-library-card.component.html',
  styleUrls: ['./user-library-card.component.css']
})
export class UserLibraryCardComponent implements OnInit {

  constructor(private toastr:ToastrService,public userService:UserService ,public home:HomeService, private router:Router, public Sounds:SoundsService) { }

   categoryName :string|undefined
   image :string|undefined
   categoryID : number|undefined
   catName:any=''
   catId:number=0;
   searchUser=new FormControl();

  ngOnInit(): void {
this.userService.GetAllUsers();
  }

  // showProfile(){
  //   this.home.selectedCat={
  //     catName:this.categoryName,
  //     catID:this.catId
  //   }
  //   this.router.navigate(['clinet/profile'])
  // }
  
  
    // inputValue(ev:any){
    //   this.catName=ev.target.value;
    //   console.log(ev.target.value);
      
    // }
  
  
  
    
    // search(){
    //   const courseobj={
    //     catName:this.catName
    //   }
    //   this.home.searchCourse(courseobj);
    // }
  
    getSounds(userID:number){
  
      this.router.navigate(["user-sounds"])
      this.Sounds.soundsUploadedByTheUser(userID)
      
    }
  
  
  
  
  
    GetByUserName(){
      this.userService.getUserByUserName(this.searchUser.value)
    }
  
  
    // GetSongs(){
  
    //   const id:number=this.catId
    //   this.Sounds.getBySoundByCategoryId(id);
    //   this.router.navigate(['clinet/sounds']);
  
  
    // }

}
