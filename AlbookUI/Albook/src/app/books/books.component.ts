import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: any[] = [];

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://your-api-url/api/books')
      .subscribe(data => {
        this.books = data;
      });
  }

  viewDetails(id: number): void {
    this.router.navigate(['/books', id]);
  }
}
