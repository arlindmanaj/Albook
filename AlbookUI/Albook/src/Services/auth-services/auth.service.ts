import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment.development';
import { LoginRequest } from '../../Models/login-models/login-request.model';
import { LoginResponse } from '../../Models/login-models/login-response.model';
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private jwtService: JwtService) { }

  login(model: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${environment.apiBaseUrl}/api/Auth/login`, model);
  }

  logout(): void {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
  }

  getToken(): string | null {
    return this.jwtService.getToken();
  }
  saveToken(token: string): void {
    return this.jwtService.saveToken(token);
  }
  isAdmin(): boolean {
    return this.jwtService.isAdmin();
  }
  isAuthenticated(): boolean {
    return this.jwtService.isAuthenticated();
  }
  private setUserRole(role: string): void {
    if (typeof window !== 'undefined') {
      window.localStorage.setItem('userRole', role);
    }
  }

  private clearUserRole(): void {
    if (typeof window !== 'undefined') {
      window.localStorage.removeItem('userRole');
    }
  }

  getUserRole(): string | null {
    if (typeof window !== 'undefined') {
      return window.localStorage.getItem('userRole');
    }
    return null;
  }
}

