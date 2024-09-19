import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChapterService } from '../../../Services/chapter-service/chapters.service';
import { Chapter } from '../../../Models/chapter-models/chapter.model';

@Component({
  selector: 'app-edit-chapter',
  templateUrl: './edit-chapter.component.html',
  styleUrls: ['./edit-chapter.component.css']
})
export class EditChapterComponent implements OnInit {
  chapterId: string = '';
  title: string = '';
  content: string = '';
  chapterNumber: number = 0;
  bookId: string = '';

  constructor(
    private chapterService: ChapterService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.chapterId = this.route.snapshot.paramMap.get('chapterId')!;
  }

  ngOnInit(): void {
    // Fetch chapter details based on chapterId
    this.chapterService.getChapterById(this.chapterId)
      .subscribe((chapter: Chapter) => {
        this.title = chapter.title;
        this.content = chapter.content;
        this.chapterNumber = chapter.chapterNumber;
        this.bookId = chapter.bookId!;
      });
  }

  // Handle form submission
  onSubmit(): void {
    const updatedChapter: Chapter = {
      chapterId: parseInt(this.chapterId, 10),
      title: this.title,
      content: this.content,
      chapterNumber: this.chapterNumber,
      bookId: this.bookId,



    };
    console.log(this.bookId);
    console.log(updatedChapter);
    this.chapterService.updateChapter(updatedChapter.chapterId, updatedChapter)
      .subscribe(() => {
        if (this.bookId) {
          console.log('Navigating to book details with bookId:', this.bookId);
          this.router.navigate([`/books/${this.bookId}`]);  // Make sure to navigate to the correct route
        } else {
          console.error('Book ID is undefined!');
        }
      }, error => {
        console.error('Error updating chapter:', error);
      });
  }
}
