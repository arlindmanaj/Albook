import { Component } from '@angular/core';
import { CategoryService } from '../../../../Services/category-service/category.service';
import { Router } from '@angular/router';
import { Category } from '../../../../Models/category-models/category.model';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  name = '';

  constructor(private categoryService: CategoryService, private router: Router) { }

  addCategory(): void {
    const newCategory: Category = { categoryId: 0, name: this.name };
    this.categoryService.addCategory(newCategory).subscribe(() => {
      this.router.navigate(['/admin/manage-categories']);
    });
  }
}
