import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email = '';
  password = '';

  apiUrl = 'http://localhost:5101/api/auth/login';

  constructor(private http: HttpClient, private router: Router, private authService: AuthService) {}

  login() {
    const body = { email: this.email, password: this.password };

    this.http.post<any>(this.apiUrl, body).subscribe({
      next: (res) => {
        this.authService.setSession(res.token, res.role, res.name);
        alert(`✅ Welcome ${res.name}!`);
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        alert('❌ Login failed: ' + (err.error || err.message));
      }
    });
  }
}
