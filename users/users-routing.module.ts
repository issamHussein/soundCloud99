import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DownloadedSoundsComponent } from './downloaded-sounds/downloaded-sounds.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserDashbourdComponent } from './user-dashbourd/user-dashbourd.component';
import { UserManageSoundComponent } from './user-manage-sound/user-manage-sound.component';
import { UserReportsComponent } from './user-reports/user-reports.component';

const routes: Routes = [


// {
//   path:"login",
//   component: LoginComponent
// },
// {
//   path:"register",
//   component: RegisterComponent
// },
{
  path:"manage-sounds",
  component: UserManageSoundComponent
},
{
  path:"user-sounds",
  component:DownloadedSoundsComponent
},
{
  path:"reports",
  component:UserReportsComponent
},

{
  path:"",
  component:UserDashbourdComponent
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
