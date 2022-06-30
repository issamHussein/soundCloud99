import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TestimonialService } from 'src/app/services/testimonial.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-testimonial',
  templateUrl: './create-testimonial.component.html',
  styleUrls: ['./create-testimonial.component.css']
})
export class CreateTestimonialComponent implements OnInit {

  delete:string="assets/img/delete.png"


  constructor(public test:TestimonialService, public userService:UserService) { }
  CreateForm: FormGroup=new FormGroup({
    message: new FormControl('',Validators.required),
    userID: new FormControl('',Validators.required),

  })
  userEmail=localStorage.getItem("email");

  save(userID:any){

    console.log(userID);
    console.log(this.CreateForm.value.message);

    this.CreateForm.value.userID=userID
    this.test.CreateTestimonial(this.CreateForm.value);
    window.location.reload();

  }

  ngOnInit(): void {
    this.userService.GetUserByEmail(this.userEmail)

  }

}
