import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-owner-reservations',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './owner-reservations.component.html',
  styleUrls: ['./owner-reservations.component.css']
})
export class OwnerReservationsComponent implements OnInit {
  reservations: any[] = [];
  apiUrl = 'http://localhost:5101/api/reservations';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadReservations();
  }

  loadReservations() {
    this.http.get<any[]>(`${this.apiUrl}/owner`, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => this.reservations = res,
      error: (err) => console.error('❌ Failed to load reservations', err)
    });
  }

  updateStatus(id: number, status: string) {
    this.http.put(`${this.apiUrl}/${id}/status`, `"${status}"`, {
      headers: { 
        Authorization: `Bearer ${localStorage.getItem('token')}`,
        'Content-Type': 'application/json'
      }
    }).subscribe({
      next: () => {
        alert(`✅ Reservation ${status}`);
        this.loadReservations();
      },
      error: (err) => alert('❌ Failed to update: ' + (err.error?.message || err.message))
    });
  }
}
