import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class JwtService {

 

  private localStorage: Storage | null = null;

  constructor() { 
    if (typeof window !== 'undefined') {
      this.localStorage = window.localStorage;
    }
  }

  setToken(token: string): void {
    this.localStorage?.setItem('authToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }
  saveToken(token: string): void {
    localStorage.setItem('token', token);
    this.decodeToken(); // Decode the token whenever we save it
  }
  clearToken(): void {
    this.localStorage?.removeItem('authToken');
  }
  isAuthenticated(): boolean {
    const token = this.getToken();
    const helper = new JwtHelperService();
    
    return token ? !helper.isTokenExpired(token) : false;
  }
 
  getRole(): string | null {
      const role = localStorage.getItem('userRole');
      if (role) {
        
        return role;
      }
      return null;
    //   const role = localStorage.getItem('userRole');
    // console.log('Retrieved role from localStorage:', role);
    // return role === 'Admin';
   }

   isAdmin(): boolean {
    return this.getRole() === "Admin";
  }

    decodeToken(): any {
      const token = this.getToken();
      if (token) {
        // Here you can use a JWT library to decode the token
        return JSON.parse(atob(token.split('.')[1]));
      }
      return null;
    }

    getUserId(): string | null{
      const token = this.getToken();
      if (token) {
        const decodedToken = this.decodeToken();
        return decodedToken.userId;
      }
      return null;
    }
}
