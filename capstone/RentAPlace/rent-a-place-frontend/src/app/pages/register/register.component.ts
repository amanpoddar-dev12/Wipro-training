import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { NotificationComponent } from '../../shared/notification/notification.component';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  name = '';
  email = '';
  password = '';
  role = 'User'; // default role

  apiUrl = 'http://localhost:5101/api/auth/register';

  constructor(private http: HttpClient, private router: Router,private notify: NotificationService) {}
    @ViewChild('notifier') notifier!: NotificationComponent;
  register() {
    const body = {
      name: this.name,
      email: this.email,
      password: this.password,
      role: this.role
    };

    this.http.post(this.apiUrl, body).subscribe({
      next: (res) => {
       this.notify.show(`✅ Welcome !`, 'success', '');
      this.router.navigate(['/home']);
          
      },
      error: (err) => {
        alert('❌ Registration failed: ' + (err.error || err.message));
      }
    });

  }
   goToLogin() {
  this.router.navigate(['/login']);
}
}
