import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HomeService } from 'src/app/services/home.service';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';
import { WelcomService } from 'src/app/services/welcom.service';

@Component({
  selector: 'app-user-library',
  templateUrl: './user-library.component.html',
  styleUrls: ['./user-library.component.css']
})
export class UserLibraryComponent implements OnInit {

  img1:string="assets/img/img1.jpg";
  img4:string="assets/img/img4.jpg";
  img5:string="assets/img/img5.jpg";

  
  img6:string="assets/img/img6.jpg";
  img9:string="assets/img/img9.jpg";
  img10:string="assets/img/img10.jpg";
  img11:string="assets/img/img11.jpg";
  img12:string="assets/img/img12.jpg";
  img13:string="assets/img/img13.jpg";



  constructor(private router :Router, public welcomService:WelcomService) { }

  ngOnInit(): void {
    this.welcomService.GetAllHome();

  }
  goToLibraryCard(){
    this.router.navigate(['user-library-card']);

  }


}
