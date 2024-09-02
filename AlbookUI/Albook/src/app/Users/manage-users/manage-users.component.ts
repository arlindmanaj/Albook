import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../../Services/user-services/user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {
  users: User[] = [];

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe(users => {
      this.users = users;
    });
  }

  addUser(): void {
    this.router.navigate(['admin/add-user']);
  }

  editUser(id: number): void {
    this.router.navigate([`admin/edit-user/${id}`]);
  }

  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe(() => {
      this.loadUsers();
    });
  }
}
