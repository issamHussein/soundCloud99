import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateAccountantComponent } from '../create-accountant/create-accountant.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountentService } from 'src/app/services/accountent.service';

@Component({
  selector: 'app-manage-accountant',
  templateUrl: './manage-accountant.component.html',
  styleUrls: ['./manage-accountant.component.css']
})
export class ManageAccountantComponent implements OnInit {
  @ViewChild('callUpdateDailog') callUpdateDailog!: TemplateRef<any>
  @ViewChild('callDeleteDailog') callDeleteDailog!: TemplateRef<any>

  constructor(private dialog: MatDialog, public accountants: AccountentService) { }
  accountant: any = {};
  isChanged: any = 0
  ngOnInit(): void {
    this.accountants.GetAllAccountent();
  }
  create() {
    this.dialog.open(CreateAccountantComponent, {
      height: '533px',
      width: '376px',
    });
  }
  searchAccountant=new FormControl();
  delete:string="assets/img/delete.png"

  openUpdateDailog(
    accountantID1: any, accountantName1: any, salary1: any, email1: any, password1: any, roleID1: any, Image1: any) {
    this.accountant = {
      accountantID: accountantID1,
      accountantName: accountantName1,
      salary: salary1,
      email: email1,
      password: password1,
      roleID: roleID1,
      image: Image1,
    }
    this.UpdateForm.controls['accountantID'].setValue(this.accountant.accountantID)
    this.dialog.open(this.callUpdateDailog, {
      height: '533px',
      width: '376px',
    });
  }


  UpdateForm: FormGroup = new FormGroup({
    accountantID: new FormControl('', Validators.required),
    accountantName: new FormControl('', Validators.required),
    salary: new FormControl('', Validators.required),
    email:new FormControl('',[Validators.required , Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    roleID: new FormControl('', Validators.required),
    image: new FormControl('', Validators.required),

  })


  uploadImage(file: any) {
    if (file.length === 0)
      return;
    this.isChanged = 1
    const uploadfile = <File>file[0];
    // {
    //   file[0]:'photo1.png',
    // }
    const formData = new FormData();
    formData.append('file', uploadfile, uploadfile.name);
    this.accountants.uploadAttachment(formData);
  }


  update() {

    this.UpdateForm.value.roleID = 2
    if (this.isChanged === 0) {
      this.accountants.display_Image = this.UpdateForm.value.image
      this.accountants.updateAccountent(this.UpdateForm.value);
    }
    else {
      this.accountants.updateAccountent(this.UpdateForm.value);
    }

  }


  openDeleteDailog(accID: number) {
    const dialogRef = this.dialog.open(this.callDeleteDailog);
    dialogRef.afterClosed().subscribe((res) => {
      if (res !== undefined) {
        if (res == 'yes')
          this.accountants.delete(accID);
        else if (res == 'no')
          console.log("Thank you ");

      }
    })


  }

  GetByAccountantName(){
    this.accountants.getAccountantByAccountantName(this.searchAccountant.value)
  }


}
