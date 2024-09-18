import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../../../Services/book-services/book.service';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrls: ['./delete-book.component.css']
})
export class DeleteBookComponent implements OnInit {
  bookId: string;

  constructor(private bookService: BookService, private route: ActivatedRoute, private router: Router) {
    this.bookId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.bookService.deleteBook(this.bookId)
      .subscribe(() => {
        this.router.navigate(['/books']);
      });
  }
}
