import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule, DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(private router: Router,@Inject(DOCUMENT) private document: Document) { 
    const localStorage = document.defaultView?.localStorage
  }
  logout(): void {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
    this.router.navigate(['/login']);

  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('userRole');
    
  }

  isAdmin(): boolean {
    const role = localStorage.getItem('userRole');
    console.log('Retrieved role from localStorage:', role);
    return role === 'Admin';
  }

  isUser(): boolean {
    const role = localStorage.getItem('userRole');
    console.log('Retrieved role from localStorage:', role);
    return role === 'User';
  }

  isLoggedInAndAdmin(): boolean {
    const token = localStorage.getItem('authToken');
    const role = localStorage.getItem('userRole');
    console.log('Retrieved role from localStorage:', role);
    return !!token && role === 'Admin';
  }

  isLoggedInAndUser(): boolean {
    const token = localStorage.getItem('authToken');
    const role = localStorage.getItem('userRole');
    console.log('Retrieved role from localStorage:', role);
    return !!token && role === 'User';
  }
}
