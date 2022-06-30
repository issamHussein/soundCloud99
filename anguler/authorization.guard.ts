import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { LoginComponent } from './users/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {
  constructor(private router: Router, private toaster: ToastrService, private dialog:MatDialog) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):
    Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const token = localStorage.getItem('token');








    if (token) 
    {

      if (state.url.indexOf('admin') >= 0) {
        let role: any = localStorage.getItem('role');
        if (role=='admin') {
          this.toaster.success('welcome');
          return true;
        }
        else {
          this.router.navigate(['admin-login']);
          this.toaster.warning('this page for admin please login');
          return false;
      }
      }

      if (state.url.indexOf('accountant') >= 0) {
        let role: any = localStorage.getItem('role');
        if (role=='accountent') {
          this.toaster.success('welcome');
          return true;
        }
        else {
          this.router.navigate(['accountant-login']);
          this.toaster.warning('this page for accountant please login');
          return false;
      }
      
      }

          return true;
    }

    else {
      
      if (state.url.indexOf('admin') >= 0) {
          this.router.navigate(['admin-login']);
          this.toaster.warning('this page for admin please login');
          return false;
      }
      

      if (state.url.indexOf('accountant') >= 0) {
          this.router.navigate(['accountant-login']);
          this.toaster.warning('this page for accountant please login');
          return false;
      }
      
      this.dialog.open(LoginComponent)   
      this.toaster.warning('Please login !!')
      return false;
    }











  }

}
  

