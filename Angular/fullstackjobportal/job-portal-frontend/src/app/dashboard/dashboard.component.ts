import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
// import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-dashboard',
  template: `
    <h2>Admin Dashboard</h2>
    <button *ngIf="role==='Admin'">Add Job</button>
  `
})
export class DashboardComponent {
  role: string | null;
  constructor(private auth: AuthService) {
    this.role = this.auth.getRole();
  }
}
