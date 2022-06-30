import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountantLoginComponent } from './accountant/accountant-login/accountant-login.component';
import { AccountantModule } from './accountant/accountant.module';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';
import { AdminModule } from './admin/admin.module';
import { AuthorizationGuard } from './authorization.guard';
import { ClinetModule } from './clinet/clinet.module';
import { ContactusComponent } from './clinet/contactus/contactus.component';
import { UsersModule } from './users/users.module';

const routes: Routes = [

{
  path:"",
  loadChildren:()=> ClinetModule,
},
{
  path:"admin",
  loadChildren:()=> AdminModule,
  canActivate:[AuthorizationGuard]
},

{
  path:"users",
  loadChildren:()=> UsersModule,
  canActivate:[AuthorizationGuard]
},
{
  path:"accountant",
  loadChildren:()=> AccountantModule,
  canActivate:[AuthorizationGuard]
},
{
  path:"admin-login",
  component:AdminLoginComponent

},
{
  path:"accountant-login",
  component:AccountantLoginComponent

},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
