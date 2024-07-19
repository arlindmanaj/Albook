import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) { }

  login(): void {
    this.http.post('http://your-api-url/api/auth/login', { username: this.username, password: this.password })
      .subscribe(
        (response: any) => {
          localStorage.setItem('token', response.token); // Store the JWT token
          this.router.navigate(['/admin']); // Navigate to admin dashboard
        },
        error => {
          alert('Invalid credentials');
        }
      );
  }
}
