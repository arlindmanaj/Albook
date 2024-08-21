import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './auth.guard';
import { FormsModule } from '@angular/forms'
import { AddBookComponent } from './add-book/add-book.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { DeleteBookComponent } from './delete-book/delete-book.component';
import { ManageUsersComponent } from './Users/manage-users/manage-users.component';
import { AddUserComponent } from './Users/add-user/add-user.component';
import { EditUserComponent } from './Users/edit-user/edit-user.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'books', component: BooksComponent },
  { path: 'books/:id', component: BookDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminDashboardComponent, canActivate: [AuthGuard] },
  { path: 'books/edit-book', component: EditBookComponent, canActivate: [AuthGuard]  },
  { path: 'books/delete-book', component: DeleteBookComponent, canActivate: [AuthGuard]  },
  { path: 'admin/manage-users', component: ManageUsersComponent },
  { path: 'admin/add-user', component: AddUserComponent },
  { path: 'admin/edit-user/:id', component: EditUserComponent },
  { path: 'admin/add-book', component: AddBookComponent, canActivate: [AuthGuard] },
  { path: 'admin/edit-book/:id', component: EditBookComponent, canActivate: [AuthGuard] },
  { path: 'books/:id', component: BookDetailsComponent },
  //Wildcard route for handling unmatched routes

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule, FormsModule]
})
export class AppRoutingModule { }
