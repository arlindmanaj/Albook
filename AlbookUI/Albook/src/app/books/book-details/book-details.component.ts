import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { BookService } from '../../../Services/book-services/book.service';
import { Chapter } from '../../../Models/chapter-models/chapter.model';
import { ChapterService } from '../../../Services/chapter-service/chapters.service';
import { AuthService } from '../../../Services/auth-services/auth.service';
@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  bookId: string | null = null;
  book: any = {
    chapters: []
  }
  chapters?: Chapter[] = [];
  chapter: Chapter = { title: '', content: '', bookId: '', chapterId: 0, chapterNumber: 0 };
  isAdmin: boolean = false; // Based on user's role
  isEditMode: boolean = false;
  showChapterForm: boolean = false;

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router, private bookService: BookService, private chapterService: ChapterService, private authService: AuthService) { }

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('id');  // Get bookId from route
    if (bookId) {
      this.bookService.getBookById(bookId).subscribe({
        next: (data) => {
          this.book = data;
          console.log('Book details:', this.book);

          // Store bookId in local storage for later use
          localStorage.setItem('currentBookId', bookId);
        },
        error: (error) => {
          console.error('Error fetching book details:', error);
        }
      });
    } else {
      console.error('Book ID is null');
    }
    this.isAdmin = this.authService.isAdmin();
  }
  toggleChapterForm() {
    this.showChapterForm = !this.showChapterForm;
    this.isEditMode = false;
    this.resetChapterForm();
  }
  onSubmit() {
    if (this.isEditMode) {
      this.chapterService.updateChapter(this.chapter.chapterId, this.chapter).subscribe(() => {
        this.loadChapters();
        this.resetChapterForm();
      });
    } else {
      this.chapterService.addChapter(this.book.bookId, this.chapter).subscribe(() => {
        this.loadChapters();
        this.resetChapterForm();
      });
    }
  }

  navigateToEditChapter(chapter: Chapter) {

    this.bookId = this.book.bookId;
    console.log('Selected chapter:', chapter);  
    console.log('Chapter Book ID:', this.bookId);  
    this.router.navigate([`/books/${this.bookId}/edit-chapter/${chapter.chapterId}`]);
  }
  onAddChapter() {
    this.chapter.bookId = this.book.bookId;
    this.chapterService.addChapter(this.book.bookId, this.chapter).subscribe(() => {
      this.loadChapters(); // Reload chapters after adding
      this.resetChapterForm(); // Reset the form
    });
  }

  // Delete a chapter
  deleteChapter(chapterId: number) {
    this.chapterService.deleteChapter(chapterId).subscribe(() => {
      this.loadChapters();
    });
  }

  // Reload chapters after adding/editing/deleting
  loadChapters() {
    this.chapterService.getChaptersByBookId(this.book.bookId).subscribe(chapters => {
      this.chapters = chapters;
    });
  }

  resetChapterForm() {
    this.chapter = { title: '', content: '', chapterNumber: 0, chapterId: 0, bookId: this.book.bookId };
    this.isEditMode = false;
  }

  buyBook(): void {
    // Implement buy logic
    alert('Book purchased!');
  }
}
