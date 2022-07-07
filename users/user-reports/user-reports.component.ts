import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountentService } from 'src/app/services/accountent.service';
import { Workbook } from 'exceljs';
import * as fs from 'file-saver';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-reports',
  templateUrl: './user-reports.component.html',
  styleUrls: ['./user-reports.component.css']
})
export class UserReportsComponent implements OnInit {

  constructor(public userService:UserService) { }
useremail=localStorage.getItem("email")
userid:any
  ngOnInit(): void {
console.log(this.userService.GetUserIDByEmail(this.useremail));

    this.userid=this.userService.GetUserIDByEmail(this.useremail)
    console.log(this.userid);
    
  }

userObj:any=[{}]


  CreateForm: FormGroup=new FormGroup({
    dateFrom: new FormControl('',Validators.required),
    dateTo:new FormControl(),
    userID:new FormControl(),
  })


  search(userid:any){
    console.log(userid);
    
this.CreateForm.value.userID=userid
    this.userService.GetProfitReport(this.CreateForm.value )
    this.userService.GetTotalProfitReport(this.CreateForm.value )


  }

















  exportExcel() {

    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet('profit');

    worksheet.columns = [
      { header: 'sound Name', key: 'SoundName', width: 32 },
      { header: 'price', key: 'price', width: 15 },
      { header: 'payment Date', key: 'dateOfDownload', width: 30 },
      { header: 'Total Profit', key: 'sumPrice', width: 30 },

    ];

    this.userService.profit.forEach((e: {  soundName: any; price: any; dateOfDownload: any;  }) => {
      worksheet.addRow({  SoundName: e.soundName, price: e.price, dateOfDownload: e.dateOfDownload,  }, "n");
    });

    this.userService.totalProfit.forEach((e: {  sumPrice: any;  }) => {
      worksheet.addRow({   sumPrice: e.sumPrice,  }, "n");
    });




    
    workbook.xlsx.writeBuffer().then((accountent) => {
      let blob = new Blob([accountent], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, 'Financial-Report.xlsx');
    })








  }







}
