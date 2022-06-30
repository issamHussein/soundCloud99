import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from '../authorization.guard';
import { HeaderComponent } from '../shared/header/header.component';
import { HomeComponent } from './home/home.component';

import { LibraryComponent } from './library/library.component';
import { LibrarycardComponent } from './librarycard/librarycard.component';
import { ProfileComponent } from './profile/profile.component';
import { SoundsComponent } from './sounds/sounds.component';
import { UserLibraryCardComponent } from './user-library-card/user-library-card.component';
import { UsersoundsComponent } from './usersounds/usersounds.component';

const routes: Routes = [
  {
    path:"",
    component: HomeComponent
  },
  // {
  //   path:"library",
  //   component: LibraryComponent
  // },
  {
    path:"librarycard",
    component: LibrarycardComponent
  },
  {
    path:"sounds",
    component: SoundsComponent,
    canActivate:[AuthorizationGuard]

  },
  {
    path:"user-library-card",
    component: UserLibraryCardComponent

  },
  {
    path:"user-sounds",
    component: UsersoundsComponent,
    canActivate:[AuthorizationGuard]
  },
  {
    path:"home",
    component: HeaderComponent,
  },

];




@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClinetRoutingModule { }
