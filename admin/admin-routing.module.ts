import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutusComponent } from '../clinet/aboutus/aboutus.component';
import { ContactusComponent } from '../clinet/contactus/contactus.component';
import { LoginComponent } from '../users/login/login.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { CreateAdminComponent } from './create-admin/create-admin.component';
import { DashboaredComponent } from './dashboared/dashboared.component';
import { ManageAboutusComponent } from './manage-aboutus/manage-aboutus.component';
import { ManageAccountantComponent } from './manage-accountant/manage-accountant.component';
import { ManageAdminComponent } from './manage-admin/manage-admin.component';
import { ManageAlbumsComponent } from './manage-albums/manage-albums.component';
import { ManageCatComponent } from './manage-cat/manage-cat.component';
import { ManageContactusComponent } from './manage-contactus/manage-contactus.component';
import { ManageSoundComponent } from './manage-sound/manage-sound.component';
import { ManageTestimonialComponent } from './manage-testimonial/manage-testimonial.component';
import { ManageUserAlbumsComponent } from './manage-user-albums/manage-user-albums.component';
import { ManageUsersComponent } from './manage-users/manage-users.component';
import { ManageWelcomComponent } from './manage-welcom/manage-welcom.component';
import { ReportComponent } from './report/report.component';
import { Top10AdminComponent } from './top10-admin/top10-admin.component';

const routes: Routes = [
  {
    path:"dashbourd",
    component:DashboaredComponent
  },
  {
    path:"manage-aboutus",
    component:ManageAboutusComponent
  },
  {
    path:"manage-cat",
    component:ManageCatComponent
  },
  {
    path:"manage-sound",
    component:ManageSoundComponent
  },
  {
    path:"manage-accountant",
    component:ManageAccountantComponent
  },
  {
    path:"manage-users",
    component:ManageUsersComponent
  },
  {
    path:"manage-home",
    component:ManageWelcomComponent
  },
  {
    path:"manage-testimonial",
    component:ManageTestimonialComponent
  },

  {
    path:"login-admin",
    component:AdminLoginComponent
  },
  {
    path:"manage-contact",
    component:ManageContactusComponent
  },

  {
    path:"finantial-report",
    component:ReportComponent
  },
  {
    path:"manage-admin",
    component:ManageAdminComponent
  },
  {
    path:"topten",
    component:Top10AdminComponent
  },
  {
    path:"manage-albums",
    component:ManageAlbumsComponent
  }
  ,
  {
    path:"manage-user-albums",
    component:ManageUserAlbumsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
