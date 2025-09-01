import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

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

  constructor(private http: HttpClient, private router: Router) {}

  register() {
    const body = {
      name: this.name,
      email: this.email,
      password: this.password,
      role: this.role
    };

    this.http.post(this.apiUrl, body).subscribe({
      next: (res) => {
        alert('✅ Registered successfully! Now you can login.');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        alert('❌ Registration failed: ' + (err.error || err.message));
      }
    });
  }
}
