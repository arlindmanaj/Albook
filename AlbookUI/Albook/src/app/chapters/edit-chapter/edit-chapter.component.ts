import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChapterService } from '../../../Services/chapter-service/chapters.service';
import { Chapter } from '../../../Models/chapter-models/chapter.model';
import { UpdateChapter } from '../../../Models/chapter-models/update-chapter.model';

@Component({
  selector: 'app-edit-chapter',
  templateUrl: './edit-chapter.component.html',
  styleUrls: ['./edit-chapter.component.css']
})
export class EditChapterComponent implements OnInit {
  chapterId: number = 0;
  title: string = '';
  content: string = '';
  chapterNumber: number = 0;
  bookId: string | null = null;

  constructor(
    private chapterService: ChapterService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.bookId = this.route.snapshot.paramMap.get('bookId')!;
  }

  ngOnInit(): void {
    this.chapterId = +this.route.snapshot.paramMap.get('chapterId')!;

    // Retrieve bookId from local storage
    this.bookId = localStorage.getItem('currentBookId');

    console.log('Retrieved bookId from localStorage:', this.bookId);

    this.chapterService.getChapterById(this.chapterId)
      .subscribe((chapter) => {
        this.title = chapter.title;
        this.content = chapter.content;
        this.chapterNumber = chapter.chapterNumber;
      });
  }

  // Handle form submission
  onSubmit(): void {



    const updatedChapter: UpdateChapter = {
      title: this.title,
      content: this.content,
      chapterNumber: this.chapterNumber,

    };
    console.log(this.bookId);
    console.log(updatedChapter);
    this.chapterService.updateChapter(this.chapterId, updatedChapter)
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
