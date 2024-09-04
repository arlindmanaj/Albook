import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtService } from '../../Services/auth-services/jwt.service';
import { AuthService } from '../../Services/auth-services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private router: Router, private jwtService: JwtService, private authService: AuthService) {

   }
   isAdmin(): boolean {
    return this.authService.isAdmin();
  }
  

  navigateToBooks(): void {
    this.router.navigate(['/books']);
  }

  navigateToLogin(): void {
    this.router.navigate(['/login']);
  }
}
