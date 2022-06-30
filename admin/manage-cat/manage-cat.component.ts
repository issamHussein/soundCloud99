import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { HomeService } from 'src/app/services/home.service';
import { CreateCatComponent } from '../create-cat/create-cat.component';

@Component({
  selector: 'app-manage-cat',
  templateUrl: './manage-cat.component.html',
  styleUrls: ['./manage-cat.component.css']
})
export class ManageCatComponent implements OnInit {

  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>




  delete:string="assets/img/delete.png"

  constructor(private dialog: MatDialog, public home: HomeService) { }
  category: any = {};
  isChanged=0;
  searchSound=new FormControl();

  ngOnInit(): void {
    this.home.GetAllCATEGORY();
  }

  create() {
    this.dialog.open(CreateCatComponent, {
      height: '265px',
      width: '376px',
    });
  }

  openUpdateDailog(categoryid1: any, categoryName1: any, imagename1: any)
     {
    this.category = {
      categoryID: categoryid1,
      categoryName: categoryName1,
      image: imagename1,
    }

    
    this.UpdateForm.controls['categoryID'].setValue(this.category.categoryID)
    this.dialog.open(this.callUpdateDailog, {
      height: '265px',
      width: '376px',
    });
  }


  UpdateForm: FormGroup = new FormGroup({
    categoryID: new FormControl(),
    categoryName: new FormControl('', Validators.required),
    image: new FormControl()
  })

  uploadImage(file:any){
    if(file.length===0)
    return;
    this.isChanged=1;

    const uploadfile=<File>file[0];
    // {
    //   file[0]:'photo1.png',
    // }
    const formData=new FormData();
    formData.append('file',uploadfile,uploadfile.name);
    this.home.uploadAttachment(formData);
  }


  update() {
    if(this.isChanged===0){

      
      this.home.display_Image=this.UpdateForm.value.image
      this.home.updateCategory(this.UpdateForm.value);
    }
else{
    this.home.updateCategory(this.UpdateForm.value);
}

    window.location.reload();

  }



  openDeleteDailog(categoryID:number)
  {
      const dialogRef=this.dialog.open(this.callDeleteDailog);
      dialogRef.afterClosed().subscribe((res)=>{
        if(res!==undefined)
        {
          if(res=='yes')
          this.home.delete(categoryID);
          else if(res=='no')
          console.log("Thank you ");
          
        }
      })


  }


  getCategoryByCategoryName(){
    this.home.getSoundByCategoryName(this.searchSound.value)
  }

}
