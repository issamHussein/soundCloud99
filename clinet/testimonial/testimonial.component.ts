import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AuthorizationGuard } from 'src/app/authorization.guard';
import { TestimonialService } from 'src/app/services/testimonial.service';
import { CreateTestimonialComponent } from '../create-testimonial/create-testimonial.component';

@Component({
  selector: 'app-testimonial',
  templateUrl: './testimonial.component.html',
  styleUrls: ['./testimonial.component.css']
})
export class TestimonialComponent implements OnInit {

  constructor(public test:TestimonialService, private dialog: MatDialog) { }
  
  ngOnInit(): void {this.test.GetAllTestimonial()  }

  createTest() {

    this.dialog.open(CreateTestimonialComponent, {
      height: '533px',
      width: '376px',
    });

  }










}
