import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SoundsService } from 'src/app/services/sounds.service';

@Component({
  selector: 'app-downloaded-sounds',
  templateUrl: './downloaded-sounds.component.html',
  styleUrls: ['./downloaded-sounds.component.css']
})
export class DownloadedSoundsComponent implements OnInit {
  @ViewChild('callMailDialog') callMailDialog!: TemplateRef<any>

  constructor(public soundService:SoundsService) { }
  searchSound=new FormControl();
  soundObj: any = {};

  ngOnInit(): void {
  }
  GetBySOUNDName(){
    this.soundService.getSoundBySoundNameForUser(this.searchSound.value)
  }

}
