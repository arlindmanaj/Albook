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
    const token = localStorage.getItem('authToken');
    const headers = {
      'Authorization': `Bearer ${token}`
    };
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Books`, model, { headers });
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
}
