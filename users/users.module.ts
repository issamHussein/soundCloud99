import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from '../shared/shared.module';
import { UserReportsComponent } from './user-reports/user-reports.component';
import { UserDashbourdComponent } from './user-dashbourd/user-dashbourd.component';
import { UserManageSoundComponent } from './user-manage-sound/user-manage-sound.component';
import { AllSoundsComponent } from './all-sounds/all-sounds.component';
import { DownloadedSoundsComponent } from './downloaded-sounds/downloaded-sounds.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    UserReportsComponent,
    UserDashbourdComponent,
    UserManageSoundComponent,
    AllSoundsComponent,
    DownloadedSoundsComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    SharedModule
  ]
})
export class UsersModule { }
