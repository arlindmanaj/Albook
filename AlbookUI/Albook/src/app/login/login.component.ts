import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth-services/auth.service';
import { LoginRequest } from '../../Models/login-models/login-request.model';
import { LoginResponse } from '../../Models/login-models/login-response.model';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string = '';


  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    const loginRequest: LoginRequest = {
      username: this.username,
      password: this.password
    };

    console.log('Sending login request:', loginRequest);

    this.authService.login(loginRequest).subscribe({

      next: (response: LoginResponse) => {
        console.log('Login response received:', response);
        const token = response.token;
        const role = response.role;
        console.log("Role Check", role)
        if (token) {
          const decodedToken = this.decodeToken(token);
          console.log('Decoded token:', decodedToken);
          const role = response.role;
          console.log('ALLO', role)
          if (role === 'Admin') {
            localStorage.setItem('authToken', token);
            localStorage.setItem('userRole', role);
            console.log('Navigating to /admin');
            this.router.navigate(['/admin']);
          } else {
            this.error = 'Access denied. You do not have the necessary permissions.';
          }
        }
      },
      error: (err) => {
        this.error = 'Login failed. Please check your username and password.';
        console.error('Login error', err);
        if (err.error instanceof ProgressEvent) {
          console.error('ProgressEvent error:', err.message);
        } else {
          console.error('Response error:', err.error); // Inspect this to see if the response is malformed
        }
      }

    });
  }

  // private decodeToken(token: string): any {
  //   try {
  //     const payload = atob(token.split('.')[1]);
  //     return JSON.parse(payload);
  //   }
  //   catch (e) {
  //     console.error('Failed to decode token', e);
  //     return null;
  //   }
  // }
  private decodeToken(token: string): any {

    if (token) {
      const helper = new JwtHelperService();
      try {
        const decoded = helper.decodeToken(token) as string;
        return decoded;
      } catch (error) {
        console.error('Error decoding token:', error);
        return null;
      }
    }

    return null;
  }

}
