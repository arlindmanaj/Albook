import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../book-services/book.service';
import { UpdateBookRequest } from '../book-models/update-book-request.model';
import { Book } from '../book-models/book.model';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
  bookId: string;
  title: string = '';
  author: string = '';
  description: string = '';
  language: string = '';
  coverUrl: string = '';
  contentUrl: string = '';
  price: number = 0;

  constructor(private bookService: BookService, private route: ActivatedRoute, private router: Router) {
    this.bookId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.bookService.getBookById(this.bookId)
      .subscribe((book: Book) => {
        this.title = book.title;
        this.author = book.author;
        this.description = book.description;
        this.language = book.language;
        this.coverUrl = book.coverUrl;
        this.contentUrl = book.contentUrl;
        this.price = book.price;
      });
  }

  editBook(): void {
    const book: UpdateBookRequest = {
      title: this.title,
      author: this.author,
      description: this.description,
      language: this.language,
      coverUrl: this.coverUrl,
      contentUrl: this.contentUrl,
      price: this.price
    };

    this.bookService.updateBook(this.bookId, book)
      .subscribe(() => {
        this.router.navigate(['/books']);
      });
  }
}
