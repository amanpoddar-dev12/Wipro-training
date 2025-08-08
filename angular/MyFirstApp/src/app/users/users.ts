import { Component, OnInit } from '@angular/core';
import { Dataservice } from '../service/dataservice';

@Component({
  selector: 'app-users',
  standalone: false,
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class Users implements OnInit {
  users: any[] = [];
  user: any = {};
  
  constructor(private dataservice: Dataservice) { }
  
  ngOnInit() {
    // Initial load of users is not done here anymore
  }

  selectUser(user: any) {
    // Simple copy of user for editing
    this.user = {...user};
  }

  resetForm() {
    this.user = {};
  }

  getUsers() {
    // Simple get users function
    this.dataservice.getUsers().subscribe({
      next: (users) => this.users = users as any[],
      error: (err) => console.log('Error:', err)
    });
  }

  addUser() {
    // Simple add user function
    this.dataservice.addUser(this.user).subscribe({
      next: (user) => {
        this.users.push(user);
        this.resetForm();
      },
      error: (err) => console.log('Error:', err)
    });
  }

  updateUser() {
    // Simple update user function
    this.dataservice.updateUser(this.user, this.user.id).subscribe({
      next: (updatedUser) => {
        const index = this.users.findIndex(u => u.id === this.user.id);
        if (index !== -1) {
          this.users[index] = updatedUser;
        }
        this.resetForm();
      },
      error: (err) => console.log('Error:', err)
    });
  }

  deleteUser() {
    // Simple delete user function
    this.dataservice.deleteUser(this.user.id).subscribe({
      next: () => {
        this.users = this.users.filter(u => u.id !== this.user.id);
        this.resetForm();
      },
      error: (err) => console.log('Error:', err)
    });
  }
}