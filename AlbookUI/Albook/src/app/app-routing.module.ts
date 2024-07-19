import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/books.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './auth.guard';
import { FormsModule } from '@angular/forms'

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'books', component: BooksComponent },
  { path: 'books/:id', component: BookDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminDashboardComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule],
  exports: [RouterModule, FormsModule]
})
export class AppRoutingModule { }
