import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule, DOCUMENT } from '@angular/common';
import { AuthService } from '../../../Services/auth-services/auth.service';
import { JwtService } from '../../../Services/auth-services/jwt.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  private localStorage: Storage | null = null;

  constructor(private router: Router, @Inject(DOCUMENT) private document: Document, private authService: AuthService, private jwtService: JwtService) {
    if (this.document.defaultView) {
      this.localStorage = this.document.defaultView.localStorage;
    }
  }
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  onHeaderClick(): void {
    const userRole = this.jwtService.getRole();

    if(userRole === 'Admin') {
      this.router.navigate(['/admin']);
    } else {
      this.router.navigate(['/user']);
    }
  }
  

  isAdmin(): boolean {
    return this.authService.isAdmin();
  }
  goToAdminDashboard(): void {
    this.router.navigate(['/admin']);
  }
  isUser(): boolean {
    return this.authService.getUserRole() === 'User';
  }

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();

  }

  isLoggedInAndAdmin(): boolean {
    return this.authService.isAuthenticated() && this.authService.isAdmin();
  }

  isLoggedInAndUser(): boolean {
    return this.authService.isAuthenticated() && this.authService.getUserRole() === 'User';
  }
}
