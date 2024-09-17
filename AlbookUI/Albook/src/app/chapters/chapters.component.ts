import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChapterService } from '../../Services/chapter-service/chapters.service';
import { Chapter } from '../../Models/chapter-models/chapter.model';

@Component({
  selector: 'app-chapters',
  templateUrl: './chapters.component.html',
  styleUrls: ['./chapters.component.css']
})
export class ChaptersComponent implements OnInit {
  chapter: Chapter | undefined;

  constructor(
    private route: ActivatedRoute,
    private chapterService: ChapterService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const chapterId = params['chapterId'];
      this.getChapter(chapterId);
    });
  }

  getChapter(chapterId: string): void {
    this.chapterService.getChapterById(chapterId).subscribe(
      (data: Chapter) => {
        this.chapter = data;
      },
      (error) => {
        console.error('Error fetching chapter:', error);
      }
    );
  }
}
