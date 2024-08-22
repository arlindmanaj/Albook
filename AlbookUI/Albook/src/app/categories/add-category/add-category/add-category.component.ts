import { Component } from '@angular/core';
import { CategoryService } from '../../category.service';
import { Router } from '@angular/router';
import { Category } from './../../category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  name = '';

  constructor(private categoryService: CategoryService, private router: Router) {}

  addCategory(): void {
    const newCategory: Category = { categoryId: 0, name: this.name };
    this.categoryService.addCategory(newCategory).subscribe(() => {
      this.router.navigate(['/admin/manage-categories']);
    });
  }
}
