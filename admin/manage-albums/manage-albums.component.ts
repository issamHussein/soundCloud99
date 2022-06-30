import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { WelcomService } from 'src/app/services/welcom.service';
import { CreateWelcomComponent } from '../create-welcom/create-welcom.component';

@Component({
  selector: 'app-manage-albums',
  templateUrl: './manage-albums.component.html',
  styleUrls: ['./manage-albums.component.css']
})
export class ManageAlbumsComponent implements OnInit {

  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>

  constructor(private dialog: MatDialog, public welcomeServive: WelcomService) { }
welcomObj:any={};
isChanged:number=0;
  ngOnInit(): void {
    this.welcomeServive.GetAllHome();
  }
  create() {
    this.dialog.open(CreateWelcomComponent, {
      height: '533px',
      width: '376px',
    });
  }
  delete:string="assets/img/delete.png"
  UpdateForm: FormGroup = new FormGroup({
    homeId: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
    text: new FormControl(),
    text2: new FormControl(),
    image1:new FormControl('',Validators.required),
    slider1: new FormControl(),

  })

  openUpdateDailog(HomeId1: any,Description1:any,
    text1: any,text21:any, Image11: any, slider11:any ) {
    this.welcomObj = {
      homeId: HomeId1,
      description:Description1,
      text: text1,
      text2:text21,
      image1: Image11,
      slider1:slider11
    }
    this.UpdateForm.controls['homeId'].setValue(this.welcomObj.homeId)
    this.dialog.open(this.callUpdateDailog, {
      height: '533px',
      width: '376px',
    });
  }




  uploadImage(file:any){
    if(file.length===0)
    return;
    this.isChanged=1
    const uploadfile=<File>file[0];
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.welcomeServive.uploadAttachment(formData);
  }

  update() {

    if(this.isChanged===0){
      this.welcomeServive.display_Image=this.UpdateForm.value.image1
      this.welcomeServive.updateHome(this.UpdateForm.value);
    }
else{
  this.welcomeServive.updateHome(this.UpdateForm.value);
}

    window.location.reload();

  }


  openDeleteDailog(HomeId:number)
  {
      const dialogRef=this.dialog.open(this.callDeleteDailog);
      dialogRef.afterClosed().subscribe((res)=>{
        if(res!==undefined)
        {
          if(res=='yes')
          this.welcomeServive.delete(HomeId);
          else if(res=='no')
          console.log("Thank you ");
          
        }
      })




    }

}
