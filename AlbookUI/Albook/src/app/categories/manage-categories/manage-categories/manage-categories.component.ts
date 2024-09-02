import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../../Services/category-service/category.service';
import { Router } from '@angular/router';
import { Category } from '../../../../Models/category-models/category.model';

@Component({
  selector: 'app-manage-categories',
  templateUrl: './manage-categories.component.html',
  styleUrls: ['./manage-categories.component.css']
})
export class ManageCategoriesComponent implements OnInit {
  categories: Category[] = [];

  constructor(private categoryService: CategoryService, private router: Router) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }
  getCategoryById(categoryId: number): void {
    this.categoryService.getCategoryById(categoryId).subscribe(data => {
      this.categories = [data];
    });
  }
  addCategory(): void {
    this.router.navigate(['/admin/add-category']);
  }

  editCategory(categoryId: number): void {
    this.router.navigate(['/admin/edit-category', categoryId]);
  }

  deleteCategory(categoryId: number): void {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryService.deleteCategory(categoryId).subscribe(() => {
        this.loadCategories();
      });
    }
  }
}
