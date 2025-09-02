import { Component, Input } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-message-user',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './message-user.component.html',
  styleUrls: ['./message-user.component.css']
})
export class MessageUserComponent {
  @Input() propertyId!: number;
  content: string = '';
  apiUrl = 'http://localhost:5101/api/messages';

  constructor(private http: HttpClient) {}

  sendMessage() {
    const payload = { propertyId: this.propertyId, content: this.content };

    this.http.post(`${this.apiUrl}/send`, payload, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Message sent to owner!');
        this.content = '';
      },
      error: (err) => {
        console.error(err);
        alert('❌ Failed to send: ' + (err.error?.message || err.message));
      }
    });
  }
}
