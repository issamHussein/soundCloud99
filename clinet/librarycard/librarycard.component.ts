import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/services/home.service';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-librarycard',
  templateUrl: './librarycard.component.html',
  styleUrls: ['./librarycard.component.css']
})
export class LibrarycardComponent implements OnInit {

  constructor(private toastr:ToastrService, public home:HomeService, private router:Router, public Sounds:SoundsService) { }
   searchSound=new FormControl();

  ngOnInit(): void {
    this.home.GetAllCATEGORY();
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
  
    getSounds(categoryID:number){
  
      this.router.navigate(["sounds"])
      this.Sounds.getSoundByCategoryId(categoryID)

      
    }
  
  
    getCategoryByCategoryName(){
      this.home.getSoundByCategoryName(this.searchSound.value)
    }
    
  
  
  
  
    // GetSongs(){
  
    //   const id:number=this.catId
    //   this.Sounds.getBySoundByCategoryId(id);
    //   this.router.navigate(['clinet/sounds']);
  
  
    // }
  
  
  
}
