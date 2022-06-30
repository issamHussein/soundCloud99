import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboaredComponent } from './dashboared/dashboared.component';
import { ManageCatComponent } from './manage-cat/manage-cat.component';
import { SharedModule } from '../shared/shared.module';
import { CreateCatComponent } from './create-cat/create-cat.component';
import { ManageSoundComponent } from './manage-sound/manage-sound.component';
import { CreateSoundComponent } from './create-sound/create-sound.component';
import { CreateAccountantComponent } from './create-accountant/create-accountant.component';
import { ManageAccountantComponent } from './manage-accountant/manage-accountant.component';
import { ManageUsersComponent } from './manage-users/manage-users.component';
import { CreateUsersComponent } from './create-users/create-users.component';
import { CreateAboutusComponent } from './create-aboutus/create-aboutus.component';
import { ManageAboutusComponent } from './manage-aboutus/manage-aboutus.component';
import { ManageTestimonialComponent } from './manage-testimonial/manage-testimonial.component';
import { CreateWelcomComponent } from './create-welcom/create-welcom.component';
import { ManageWelcomComponent } from './manage-welcom/manage-welcom.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { ManageContactusComponent } from './manage-contactus/manage-contactus.component';
import { ReportComponent } from './report/report.component';
import { ManageAdminComponent } from './manage-admin/manage-admin.component';
import { CreateAdminComponent } from './create-admin/create-admin.component';
import { Top10AdminComponent } from './top10-admin/top10-admin.component';
import { ManageAlbumsComponent } from './manage-albums/manage-albums.component';
import { ManageUserAlbumsComponent } from './manage-user-albums/manage-user-albums.component';


@NgModule({
  declarations: [
    DashboaredComponent,
    ManageCatComponent,
    CreateCatComponent,
    ManageSoundComponent,
    CreateSoundComponent,
    CreateAccountantComponent,
    ManageAccountantComponent,
    ManageUsersComponent,
    CreateUsersComponent,
    CreateAboutusComponent,
    ManageAboutusComponent,
    ManageTestimonialComponent,
    CreateWelcomComponent,
    ManageWelcomComponent,
    AdminLoginComponent,
    ManageContactusComponent,
    ReportComponent,
    ManageAdminComponent,
    CreateAdminComponent,
    Top10AdminComponent,
    ManageAlbumsComponent,
    ManageUserAlbumsComponent,
    
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
