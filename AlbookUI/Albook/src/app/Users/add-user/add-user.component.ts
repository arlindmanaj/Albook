import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../../Services/user-services/user.service';
import { RegisterRequest } from '../models/reqister-request.model';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {
  username: string = '';
  password: string = '';
  role: string = '';
  email: string = '';

  constructor(private userService: UserService, private router: Router) { }

  addUser(): void {
    if (!this.username || !this.password || !this.role) {
      alert('Please fill in all fields.');
      return;
    };
    const newUser: RegisterRequest = {
      username: this.username,
      password: this.password,
      role: this.role,
      email: this.email
    };
    this.userService.addUser(newUser).subscribe(() => {
      this.router.navigate(['admin/manage-users']);
    });
  }
}
