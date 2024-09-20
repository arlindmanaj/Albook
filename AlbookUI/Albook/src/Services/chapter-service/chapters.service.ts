import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Chapter } from '../../Models/chapter-models/chapter.model';
import { environment } from '../../environments/environment.development';
import { UpdateChapter } from '../../Models/chapter-models/update-chapter.model';

@Injectable({
  providedIn: 'root',
})
export class ChapterService {
  private baseUrl = `${environment.apiBaseUrl}/api/Chapter`; // Adjust the URL to match your backend

  constructor(private http: HttpClient) { }

  getChaptersByBookId(bookId: string): Observable<Chapter[]> {
    return this.http.get<Chapter[]>(`${this.baseUrl}/book/${bookId}`);
  }

  getChapterById(chapterId: number): Observable<Chapter> {
    return this.http.get<Chapter>(`${this.baseUrl}/${chapterId}`);
  }
  addChapter(bookId: string, chapter: Chapter): Observable<Chapter> {
    return this.http.post<Chapter>(`${this.baseUrl}/add`, { ...chapter, bookId });
  }

  // Update an existing chapter
  updateChapter(chapterId: number, updateChapter: UpdateChapter): Observable<Chapter> {
    console.log(`Updating chapter ${chapterId} with data:`, updateChapter);
    return this.http.put<Chapter>(`${this.baseUrl}/${chapterId}`, updateChapter);
  }

  // Delete a chapter by ID
  deleteChapter(chapterId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${chapterId}`);
  }

}
