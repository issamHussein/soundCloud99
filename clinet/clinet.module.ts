import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClinetRoutingModule } from './clinet-routing.module';
import { LibraryComponent } from './library/library.component';
import { SharedModule } from '../shared/shared.module';
import { SoundsComponent } from './sounds/sounds.component';
import { ProfileComponent } from './profile/profile.component';
import { HomeComponent } from './home/home.component';
import { ContactusComponent } from './contactus/contactus.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { TestimonialComponent } from './testimonial/testimonial.component';
import { LibrarycardComponent } from './librarycard/librarycard.component';
import { CreateTestimonialComponent } from './create-testimonial/create-testimonial.component';
import { UserLibraryComponent } from './user-library/user-library.component';
import { UserLibraryCardComponent } from './user-library-card/user-library-card.component';
import { UsersoundsComponent } from './usersounds/usersounds.component';
import { Top10Component } from './top10/top10.component';
import { OurTeamComponent } from './our-team/our-team.component';

@NgModule({
  declarations: [
    LibraryComponent,
    SoundsComponent,
    ProfileComponent,
    HomeComponent,
    ContactusComponent,
    AboutusComponent,
    WelcomeComponent,
    TestimonialComponent,
    LibrarycardComponent,
    CreateTestimonialComponent,
    UserLibraryComponent,
    UserLibraryCardComponent,
    UsersoundsComponent,
    Top10Component,
    OurTeamComponent,
    
  ],
  imports: [
    CommonModule,
    ClinetRoutingModule,
    SharedModule
  ]
})
export class ClinetModule { }
