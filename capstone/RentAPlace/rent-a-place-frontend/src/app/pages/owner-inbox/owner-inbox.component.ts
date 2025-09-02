import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-owner-inbox',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './owner-inbox.component.html',
  styleUrls: ['./owner-inbox.component.css']
})
export class OwnerInboxComponent implements OnInit {
  messages: any[] = [];
  replyContent: { [key: number]: string } = {};
  apiUrl = 'http://localhost:5101/api/messages';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.http.get<any[]>(`${this.apiUrl}/inbox`, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => this.messages = res,
      error: (err) => console.error('❌ Failed to load messages', err)
    });
  }

  sendReply(messageId: number) {
    const content = this.replyContent[messageId];
    if (!content) return;

    this.http.post(`${this.apiUrl}/reply/${messageId}`, `"${content}"`, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem('token')}`,
        'Content-Type': 'application/json'
      }
    }).subscribe({
      next: () => {
        alert('✅ Reply sent!');
        this.replyContent[messageId] = '';
        this.loadMessages();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  }
}
