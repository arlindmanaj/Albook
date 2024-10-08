import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HomeComponent } from './home/home.component';
import { BooksComponent } from './books/book-component/books.component';
import { BookDetailsComponent } from './books/book-details/book-details.component';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AddBookComponent } from './books/add-book/add-book.component';
import { EditBookComponent } from './books/edit-book/edit-book.component';
import { DeleteBookComponent } from './books/delete-book/delete-book.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { ManageUsersComponent } from './Users/manage-users/manage-users.component';
import { AddUserComponent } from './Users/add-user/add-user.component';
import { EditUserComponent } from './Users/edit-user/edit-user.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { ManageCategoriesComponent } from './categories/manage-categories/manage-categories/manage-categories.component';
import { AddCategoryComponent } from './categories/add-category/add-category/add-category.component';
import { EditCategoryComponent } from './categories/edit-category/edit-category/edit-category.component';
import { ChaptersComponent } from './chapters/chapters-component/chapters.component';
import { EditChapterComponent } from './chapters/edit-chapter/edit-chapter.component';
import { MarkdownModule } from 'ngx-markdown';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BooksComponent,
    BookDetailsComponent,
    LoginComponent,
    AdminDashboardComponent,
    AddBookComponent,
    EditBookComponent,
    DeleteBookComponent,
    ManageUsersComponent,
    AddUserComponent,
    EditUserComponent,
    NavbarComponent,
    ManageCategoriesComponent,
    AddCategoryComponent,
    EditCategoryComponent,
    ChaptersComponent,
    EditChapterComponent

  ],
  imports: [


    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MarkdownModule.forRoot(),

  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync(),
    provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
