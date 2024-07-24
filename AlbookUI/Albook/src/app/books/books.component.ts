import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../book-services/book.service';
import { Book } from '../book-models/book.model';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.bookService.getAllBooks()
      .subscribe(data => {
        this.books = data;
      });
  }

  viewDetails(id: number): void {
    this.router.navigate(['/books', id]);
  }
}
