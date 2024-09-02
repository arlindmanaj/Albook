import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../Services/book-services/book.service';
import { AddBookRequest } from '../book-models/add-book-request.model';
import { CategoryService } from '../../Services/category-service/category.service';
import { Category } from '../categories/category-models/category.model';
import { Translation } from '../Translations/translations/translations.model';
@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent {
  title: string = '';
  author: string = '';
  description: string = '';
  language: string = '';
  coverUrl: string = '';
  contentUrl: string = '';
  price: number = 0;

  selectedCategories: Category[] = [];

  existingCategories: Category[] = [];
  translations: Translation[] = [];

  constructor(private bookService: BookService, private router: Router, private categoryService: CategoryService) { }
  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.existingCategories = data;
    });
  }

  onCategoryChange(event: Event, category: Category): void {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      this.selectedCategories.push(category);
    } else {
      this.selectedCategories = this.selectedCategories.filter(c => c.categoryId !== category.categoryId);
    }
  }

  addBook(): void {
    const book: AddBookRequest = {
      title: this.title,
      author: this.author,
      description: this.description,
      language: this.language,
      coverUrl: this.coverUrl,
      contentUrl: this.contentUrl,
      price: this.price,
      categoryIds: this.selectedCategories.map(c => c.categoryId),
      translations: this.translations
    };
    console.log(book);

    this.bookService.addBook(book)
      .subscribe(() => {
        this.router.navigate(['/books']);
      });
  }
}
