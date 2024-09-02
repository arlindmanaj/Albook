import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../Services/auth-services/auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router,
    private authService: AuthService
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    const token = localStorage.getItem('authToken');
    if (token && this.authService.isAuthenticated()) {
      console.log('AuthGuard: token found, allowing access');
      return true;
    } else {
      this.router.navigate(['/login']);
      console.log('AuthGuard: no token found');
      return false;
    }
  }
}
