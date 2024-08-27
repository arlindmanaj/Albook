import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../book-services/book.service';
import { UpdateBookRequest } from '../book-models/update-book-request.model';
import { Book } from '../book-models/book.model';
import { CategoryService, Category } from '../categories/category.service';

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
  categoryName: string = '';
  categories: Category[] = [];

  constructor(private bookService: BookService, private route: ActivatedRoute, private router: Router, private categoryService: CategoryService) {
    this.bookId = this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    console.log('Editing Book ID:', this.bookId);
    this.bookService.getBookById(this.bookId)
      .subscribe((book: Book) => {

        console.log('Book Data Retrieved:', book);
        this.title = book.title;
        this.author = book.author;
        this.description = book.description;
        this.language = book.language;
        this.coverUrl = book.coverUrl;
        this.contentUrl = book.contentUrl;
        this.price = book.price;
        this.categoryName = book.categoryName;
        console.log('Book Category Name:', this.categoryName);
      });
    this.categoryService.getCategories().subscribe(data => {
      console.log('Categories Retrieved:', data);
      this.categories = data;
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
      price: this.price,
      categoryName: this.categoryName
    };
    console.log('Book Data to Update:', book);

    this.bookService.updateBook(this.bookId, book)
      .subscribe(() => {
        console.log('Book successfully updated, navigating to /books');
        this.router.navigate(['/books']);
      }, error =>{
        console.error('Error updating book:', error);
      });
  }
}

