import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { User } from '../../app/Users/models/user.model';
import { RegisterRequest } from '../../app/Users/models/reqister-request.model';
import { ChangeRoleRequest } from '../../app/Users/models/change-role-request.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiBaseUrl}/api/Users`);
  }

  addUser(model: RegisterRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Auth/register`, model);
  }

  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiBaseUrl}/api/Users/${id}`);
  }

  changeUserRole(id: number, model: ChangeRoleRequest): Observable<void> {
    return this.http.put<void>(`${environment.apiBaseUrl}/api/Users/${id}/role`, model);
  }

  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${environment.apiBaseUrl}/api/Users/${id}`);
  }

  updateUser(id: number, model: ChangeRoleRequest): Observable<void> {
    return this.http.put<void>(`${environment.apiBaseUrl}/api/Users/${id}/role`, model);
  }
}
