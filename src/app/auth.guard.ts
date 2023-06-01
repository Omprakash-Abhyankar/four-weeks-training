// import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';
// import { Observable } from 'rxjs';
// export const AuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable <boolean> | Promise<boolean> => {
//   // Implement your authentication logic here
//   // You can use AuthService to check if the user is authenticated

//   // if (/* Your authentication condition */) {
//     return true;
//   // } else {
//   //   // Redirect to login or any other action
//   //   return false;
//   // }
// };



// import { Injectable } from '@angular/core';
// import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
// import { Observable } from 'rxjs';
// import { SellerService} from './services/seller.service';
// import { Router } from '@angular/router';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthGuard implements CanActivateFn {
//   constructor(private sellerService: SellerService, private router: Router) {}
//   CanActivateFn(
//     route: ActivatedRouteSnapshot,
//     state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

//   return true;
//     }
// };




import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
// import { AuthService } from './auth.service';
import { SellerService } from './services/seller.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private sellerService: SellerService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    if (this.sellerService.isSellerLoggedIn) {
      return true;
    } else {
      return false;
      //this.router.parseUrl('/seller-home');
    }
  }
}
