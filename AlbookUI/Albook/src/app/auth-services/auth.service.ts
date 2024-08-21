import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment.development';
import { LoginRequest } from '../login-models/login-request.model';
import { LoginResponse } from '../login-models/login-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(model: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.apiBaseUrl}/api/Auth/login`, model);
  }

  logout(): void {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
  isAuthenticated(): boolean {
    const token = localStorage.getItem('authToken');
    return !!token;
  }
}
