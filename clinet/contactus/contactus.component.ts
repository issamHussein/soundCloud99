import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AboutUsService } from 'src/app/services/about-us.service';
import { ContactUsService } from 'src/app/services/contact-us.service';

@Component({
  selector: 'app-contactus',
  templateUrl: './contactus.component.html',
  styleUrls: ['./contactus.component.css']
})
export class ContactusComponent implements OnInit {

  constructor(public contactService:ContactUsService, public aboutService:AboutUsService) { }

  ngOnInit(): void {
  }
  CreateForm: FormGroup=new FormGroup({
    FullName: new FormControl('',Validators.required),
    Email:new FormControl('',Validators.required),
    Message:new FormControl('',Validators.required),
  })

  save(){
    this.contactService.createContactus(this.CreateForm.value);
    window.location.reload();
  }


}
