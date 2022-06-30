import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AboutUsService } from 'src/app/services/about-us.service';
import { CreateAboutusComponent } from '../create-aboutus/create-aboutus.component';

@Component({
  selector: 'app-manage-aboutus',
  templateUrl: './manage-aboutus.component.html',
  styleUrls: ['./manage-aboutus.component.css']
})
export class ManageAboutusComponent implements OnInit {
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>

  constructor(private dialog: MatDialog, public aboutService: AboutUsService) { }
  aboutUsObj: any = {};
  isChanged=0;

  delete:string="assets/img/delete.png"



  ngOnInit(): void {
    this.aboutService.GetAllAboutUs();
  }
  create() {
    this.dialog.open(CreateAboutusComponent, {
      height: '533px',
      width: '376px',
    });
  }

  UpdateForm: FormGroup = new FormGroup({
    aboutusID: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
    image:new FormControl(),
    email:new FormControl('',[Validators.required , Validators.email]),
        phonenumber: new FormControl('',Validators.required),
        location: new FormControl('',Validators.required),

  })


  openUpdateDailog(aboutusID1: any,
    description1: any, imagename1: any, email1:any, phonenumber1:any, location1:any) {
    this.aboutUsObj = {
      aboutusID: aboutusID1,
      description: description1,
      image: imagename1,
      email:email1,
      phonenumber:phonenumber1,
      location:location1
    }
    this.UpdateForm.controls['aboutusID'].setValue(this.aboutUsObj.aboutusID)
    this.dialog.open(this.callUpdateDailog, {
      height: '533px',
      width: '376px',
    });
  }


 




  uploadImage(file:any){
    if(file.length===0)
    return;
    this.isChanged=1;
    const uploadfile=<File>file[0];
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.aboutService.uploadAttachment(formData);
  }

  update() {
console.log(this.isChanged);

if(this.isChanged===0){
  this.aboutService.display_Image=this.UpdateForm.value.image
  this.aboutService.updateAboutUs(this.UpdateForm.value);
}
else{
    this.aboutService.updateAboutUs(this.UpdateForm.value);
  }



    window.location.reload();

  }


  openDeleteDailog(aboutusID:number)
  {
      const dialogRef=this.dialog.open(this.callDeleteDailog);
      dialogRef.afterClosed().subscribe((res)=>{
        if(res!==undefined)
        {
          if(res=='yes')
          this.aboutService.delete(aboutusID);
          else if(res=='no')
          console.log("Thank you ");
          
        }
      })




    }


}
