import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../Services/book-services/book.service';
import { Book } from '../../Models/book-models/book.model';
import { AuthService } from '../../Services/auth-services/auth.service';
import { Category } from '../../Models/category-models/category.model';
import { JwtService } from './../../Services/auth-services/jwt.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];
  categories: Category[] = [];

  constructor(private bookService: BookService, private router: Router, private authService: AuthService, private jwtService: JwtService) { }

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
    const role =  this.jwtService.getRole();
    if(role === 'Admin'){
      console.log('Retrieved role from localStorage:', role);
      return true;
      
    }
    console.log('Retrieved role from localStorage:', role);
    return false;
  }
  private decodeToken(token: string): any {
   return this.jwtService.decodeToken();
  }
}