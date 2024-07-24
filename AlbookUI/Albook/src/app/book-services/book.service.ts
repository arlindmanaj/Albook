import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Book } from '../book-models/book.model';
import { AddBookRequest } from '../book-models/add-book-request.model';
import { UpdateBookRequest } from '../book-models/update-book-request.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  addBook(model: AddBookRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Books`, model);
  }

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${environment.apiBaseUrl}/api/Books`);
  }

  getBookById(id: string): Observable<Book> {
    return this.http.get<Book>(`${environment.apiBaseUrl}/api/Books/${id}`);
  }

  updateBook(id: string, updateBookRequest: UpdateBookRequest): Observable<Book> {
    return this.http.put<Book>(`${environment.apiBaseUrl}/api/Books/${id}`, updateBookRequest);
  }

  deleteBook(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiBaseUrl}/api/Books/${id}`);
  }
}
