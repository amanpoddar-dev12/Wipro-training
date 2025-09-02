import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-inbox',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './user-inbox.component.html',
  styleUrls: ['./user-inbox.component.css']
})
export class UserInboxComponent implements OnInit {
  messages: any[] = [];
  apiUrl = 'http://localhost:5101/api/messages';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.http.get<any[]>(`${this.apiUrl}/user`, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => this.messages = res,
      error: (err) => console.error('❌ Failed to load user messages', err)
    });
  }
}
