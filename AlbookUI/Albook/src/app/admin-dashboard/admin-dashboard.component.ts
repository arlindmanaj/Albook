import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent {

  constructor(private router: Router) { }

  navigateToUsers(path: string): void {
    this.router.navigate([`/admin/${path}`]);
  }
  navigateToBooks(path: string): void {
    this.router.navigate([`books`]);
  }
  navigateToTranslations(path: string): void {
    this.router.navigate([`/admin/translations`]);
  }
  navigateToCategories(path: string): void {
    this.router.navigate([`/admin/manage-categories`]);
  }
}
