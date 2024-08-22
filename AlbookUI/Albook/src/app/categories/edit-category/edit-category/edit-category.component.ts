import { Component, OnInit } from '@angular/core';
import { CategoryService } from './../../category.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from './../../category.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {
  name = '';
  categoryId!: number;

  constructor(private categoryService: CategoryService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.categoryId = +this.route.snapshot.paramMap.get('id')!;
    this.categoryService.getCategoryById(this.categoryId).subscribe(category => {
      this.name = category.name;
    });
  }

  editCategory(): void {
    const updatedCategory: Category = { categoryId: this.categoryId, name: this.name };
    this.categoryService.updateCategory(this.categoryId, updatedCategory).subscribe(() => {
      this.router.navigate(['/admin/manage-categories']);
    });
  }
}
