import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/services/home.service';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { WelcomService } from 'src/app/services/welcom.service';
@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {
  img1:string="assets/img/asala.jpg";
  img4:string="assets/img/edd.jpg";
  img5:string="assets/img/aziz.png";
  img6:string="assets/img/nansi.jpeg";
  img9:string="assets/img/wael.jpg";
  img11:string="assets/img/faya.png";



  constructor(private router :Router, public welcomService:WelcomService) { }

  ngOnInit(): void {
    this.welcomService.GetAllHome();
    console.log(this.welcomService.data);
    
  }
  goToLibraryCard(){
    this.router.navigate(['librarycard']);

  }


}




