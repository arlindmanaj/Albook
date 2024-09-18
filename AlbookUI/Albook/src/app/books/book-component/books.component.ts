import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../../../Services/book-services/book.service';
import { Book } from '../../../Models/book-models/book.model';
import { AuthService } from '../../../Services/auth-services/auth.service';
import { Category } from '../../../Models/category-models/category.model';
import { JwtService } from '../../../Services/auth-services/jwt.service';


@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  isAdminRole: boolean = false;
  books: Book[] = [];
  categories: Category[] = [];
  book: Book | undefined;

  constructor(private route: ActivatedRoute, private bookService: BookService, private router: Router, private authService: AuthService, private jwtService: JwtService) { }

  ngOnInit(): void {
    this.bookService.getAllBooks()
      .subscribe(data => {
        this.books = data;
      });
    this.checkAdminRole();

    const bookId = this.route.snapshot.paramMap.get('id');
    if (bookId) {
      this.bookService.getBookById(bookId).subscribe({
        next: (data) => {
          this.book = data;
          console.log(this.book);  // Check the full book object

        },
        error: (error) => {
          console.error('Error fetching book details:', error);
        }
      });
    } else {
      console.error('Book ID is null');
    }
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
  private checkAdminRole(): void {
    this.isAdminRole = this.jwtService.isAdmin();
    console.log('Retrieved role from localStorage:', this.isAdminRole ? 'Admin' : 'User');
  }
  public isAdmin(): boolean {

    return this.isAdminRole;
  }
  private decodeToken(token: string): any {
    return this.jwtService.decodeToken();
  }
}