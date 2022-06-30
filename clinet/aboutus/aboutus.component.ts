import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AboutUsService } from 'src/app/services/about-us.service';

@Component({
  selector: 'app-aboutus',
  templateUrl: './aboutus.component.html',
  styleUrls: ['./aboutus.component.css']
})
export class AboutusComponent implements OnInit {

  constructor(private dialog: MatDialog, public aboutService: AboutUsService) { }
  aboutUsObj: any = {};
  ngOnInit(): void {  this.aboutService.GetAllAboutUs();
  }

}
