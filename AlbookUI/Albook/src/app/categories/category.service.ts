import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Category } from './category-models/category.model';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseUrl = `${environment.apiBaseUrl}/api/Category`;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl);
  }
  getCategoryById(categoryId: number): Observable<Category> {
    return this.http.get<Category>(`${this.baseUrl}/${categoryId}`);
  }

  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(this.baseUrl, category);
  }

  updateCategory(categoryId: number, category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.baseUrl}/${categoryId}`, category);
  }

  deleteCategory(categoryId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${categoryId}`);
  }
}
