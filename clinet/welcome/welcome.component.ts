import { Component, OnInit } from '@angular/core';
import { WelcomService } from 'src/app/services/welcom.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  constructor(public welcomService:WelcomService) { }
  aboutUsObj: any = {};

  ngOnInit(): void {this.welcomService.GetAllHome();
    
  }

}
