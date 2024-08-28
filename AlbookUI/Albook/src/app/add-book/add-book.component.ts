import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../book-services/book.service';
import { AddBookRequest } from '../book-models/add-book-request.model';
import { CategoryService } from '../categories/category.service';
import { Category } from './../categories/category.service';
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

  categories: Category[] = [];

  constructor(private bookService: BookService, private router: Router, private categoryService: CategoryService) { }
  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
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
      categories: this.categories
    };
   
  
    this.bookService.addBook(book)
      .subscribe(() => {
        this.router.navigate(['/books']);
      });
  }
}
