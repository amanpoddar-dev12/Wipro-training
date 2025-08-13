import { Component, OnInit } from '@angular/core';
import { DataserviceService } from '../../service/dataservice.service';

@Component({
  selector: 'app-users',
  standalone: false,
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  user: any = { firstName: '', age: '' };
  editMode = false;
  editId: number | null = null;

  constructor(private dataService: DataserviceService) {}

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.dataService.getUsers().subscribe({
      next: (users) => this.users = users as any[],
      error: (err) => console.error('Error fetching users:', err)
    });
  }

  addUser() {
    if (this.editMode && this.editId !== null) {
      this.dataService.updateUser(this.editId, this.user).subscribe(() => {
        this.getUsers();
        this.resetForm();
      });
    } else {
      this.dataService.addUser(this.user).subscribe(() => {
        this.getUsers();
        this.resetForm();
      });
    }
  }

  editUser(user: any) {
    this.user = { ...user };
    this.editMode = true;
    this.editId = user.id;
  }

  deleteUser(id: number) {
    this.dataService.deleteUser(id).subscribe(() => {
      this.getUsers();
    });
  }

  resetForm() {
    this.user = { firstName: '', age: '' };
    this.editMode = false;
    this.editId = null;
  }
}
