import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../book-services/book.service';
import { Book } from '../book-models/book.model';
import { AuthService } from '../auth-services/auth.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.bookService.getAllBooks()
      .subscribe(data => {
        this.books = data;
      });
  }
  addBook(): void {
    this.router.navigate(['admin/add-book']);
  }

  editBook(id: string): void {
    this.router.navigate(['admin/edit-book', id]);
  }
  viewDetails(id: string): void {
    this.router.navigate(['/books', id]);
  }
  deleteBook(id: string): void {
    if (confirm('Are you sure you want to delete this book?')) {
      this.bookService.deleteBook(id).subscribe(() => {
        this.books = this.books.filter(book => book.bookId !== id);
      });
    }
  }

  public isAdmin(): boolean {
    const role = localStorage.getItem('userRole');
    console.log('Retrieved role from localStorage:', role);
    return role === 'Admin';
  }
  private decodeToken(token: string): any {
    try {
      const payload = atob(token.split('.')[1]);
      return JSON.parse(payload);
    }
    catch (e) {
      console.error('Failed to decode token', e);
      return null;
    }
  }
}
