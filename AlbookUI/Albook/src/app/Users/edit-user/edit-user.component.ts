import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../Services/user-services/user.service';
import { RegisterRequest } from '../models/reqister-request.model';
import { User } from '../models/user.model';
import { ChangeRoleRequest } from '../models/change-role-request.model';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  userId: number;
  username: string = '';
  password: string = '';
  role: string = '';
  email: string = '';

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {
    this.userId = +this.route.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.userService.getUserById(this.userId).subscribe((user: User) => {
      this.username = user.username;
      this.role = user.role;
    });
  }

  editUser(): void {
    const updatedUser: ChangeRoleRequest = {
      username: this.username,
      role: this.role,
     
    };

    this.userService.updateUser(this.userId, updatedUser).subscribe(() => {
      this.router.navigate(['admin/manage-users']);
    });
    error: (err: any) => {
      console.error('Error updating user', err);
      alert('An error occurred while updating the user. Please try again.');
    }
  }
}
