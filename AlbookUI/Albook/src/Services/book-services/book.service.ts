import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Book } from '../../Models/book-models/book.model';
import { AddBookRequest } from '../../Models/book-models/add-book-request.model';
import { UpdateBookRequest } from '../../Models/book-models/update-book-request.model';
@Injectable({
  providedIn: 'root'
})
export class BookService {
  private bookId: string = '';
  constructor(private http: HttpClient) { }

  addBook(model: AddBookRequest): Observable<void> {
    const token = localStorage.getItem('authToken');
    const headers = {
      'Authorization': `Bearer ${token}`
    };
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Books`, model, { headers })
  }

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${environment.apiBaseUrl}/api/Books`);
  }

  getBookById(id: string): Observable<Book> {
    const token = localStorage.getItem('authToken');
    const headers = {
      'Authorization': `Bearer ${token}`
    };
    return this.http.get<Book>(`${environment.apiBaseUrl}/api/Books/${id}`, { headers });
  }

  updateBook(id: string, updateBookRequest: UpdateBookRequest): Observable<Book> {
    const token = localStorage.getItem('authToken');
    const headers = {
      'Authorization': `Bearer ${token}`
    };
    return this.http.put<Book>(`${environment.apiBaseUrl}/api/Books/${id}`, updateBookRequest, { headers });
  }

  deleteBook(id: string): Observable<void> {
    const token = localStorage.getItem('authToken');
    const headers = {
      'Authorization': `Bearer ${token}`
    };
    return this.http.delete<void>(`${environment.apiBaseUrl}/api/Books/${id}`, { headers });
  }

  setBookId(id: string): void {
    this.bookId = id;
  }

  getBookId(): string {
    return this.bookId;
  }
}
