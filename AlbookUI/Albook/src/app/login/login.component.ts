import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth-services/auth.service';
import { LoginRequest } from '../login-models/login-request.model';
import { LoginResponse } from '../login-models/login-response.model';

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
      //qetu e ke prit si LoginResponse a nfaktikisht ne API e ke kthy veq string
      //Tash ose munesh ne backend me e maru ni model sikur kjo LoginResponse
      //Ose munesh ktu me prit si qysh e kom bo un po sdmth qe osht zgjidhja ma e mire (jo qe osht kiamet teknik asnjona) DW <3 keep going
      //next: (response: LoginResponse) => {
      next: (response: { token: string }) => {
        console.log('Login response received:', response);
        const token = response.token;
        if (token) {
          const decodedToken = this.decodeToken(token);
          console.log('Decoded token:', decodedToken);
          const role = decodedToken.role;

          if (role === 'Admin') {
            localStorage.setItem('authToken', token);
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
  private decodeToken(token: string): any {
    try {
      const payload = atob(token.split('.')[1]);
      return JSON.parse(payload);
    }
    catch (e) {
      console.error('Failed to decode token', e);
      return null;
    }
  }

}
