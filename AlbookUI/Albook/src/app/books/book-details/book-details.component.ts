import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { BookService } from '../../../Services/book-services/book.service';
@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: any;

  constructor(private route: ActivatedRoute, private http: HttpClient, private bookService: BookService) { }

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('id');
    if (bookId) {
      this.bookService.getBookById(bookId).subscribe({
        next: (data) => {
          this.book = data;
        },
        error: (error) => {
          console.error('Error fetching book details:', error);
        }
      });
    } else {
      console.error('Book ID is null');
    }
  } 

  buyBook(): void {
    // Implement buy logic
    alert('Book purchased!');
  }
}
