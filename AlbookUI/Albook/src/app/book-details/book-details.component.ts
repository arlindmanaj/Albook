import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: any;

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('id');
    this.http.get(`http://your-api-url/api/books/${bookId}`)
      .subscribe(data => {
        this.book = data;
      });
  }

  buyBook(): void {
    // Implement buy logic
    alert('Book purchased!');
  }
}
