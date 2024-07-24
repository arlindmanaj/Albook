import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth-services/auth.service';
import { LoginRequest } from '../login-models/login-request.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string | null = null;

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    const loginRequest: LoginRequest = {
      username: this.username,
      password: this.password
    };

    this.authService.login(loginRequest).subscribe({
      next: response => {
        this.router.navigate(['/admin']);
      },
      error: err => {
        this.error = 'Login failed. Please check your username and password.';
        console.error('Login error', err);
      }
    });
  }
}
