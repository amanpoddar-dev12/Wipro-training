import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { NotificationComponent } from '../../shared/notification/notification.component';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChild('notifier') notifier!: NotificationComponent;
  email = '';
  password = '';

  apiUrl = 'http://localhost:5101/api/auth/login';

 constructor(private http: HttpClient, private router: Router, private authService: AuthService, private notify: NotificationService) {}

login() {
  const body = { email: this.email, password: this.password };

  this.http.post<any>(this.apiUrl, body).subscribe({
    next: (res) => {
      this.authService.setSession(res.token, res.role, res.name);
      localStorage.setItem('token', res.token);
      this.router.navigate(["/home"]);
      this.notify.show(`✅ Welcome ${res.name}!`, 'success', '');
    },
    error: (err) => {
      this.notify.show('❌ Login failed: ' + (err.error || err.message), 'error', '');
    }
  });
}
  goToRegister() {
  this.router.navigate(['/register']);
}

}
