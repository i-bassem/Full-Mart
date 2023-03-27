import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserAuthService } from '../_services/UserAuthentication/UserAuthService';
// import {NgToastSevice} from 'ng-angular-popup';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  // private toast: NgToastSevice
  constructor(private userAuth: UserAuthService , private router:Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree
  {
    if(this.userAuth.isUserLogged)
    return true;
    else
     this.router.navigateByUrl("/userLogin")
     return false
  }
  
}
