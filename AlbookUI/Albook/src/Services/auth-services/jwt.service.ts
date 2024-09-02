import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }
  getToken(): string | null {
    return localStorage.getItem('authToken');
  }
}
