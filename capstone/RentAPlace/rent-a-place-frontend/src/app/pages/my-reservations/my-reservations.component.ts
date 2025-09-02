import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-my-reservations',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './my-reservations.component.html',
  styleUrls: ['./my-reservations.component.css']
})
export class MyReservationsComponent implements OnInit {
  reservations: any[] = [];
  apiUrl = 'http://localhost:5101/api/reservations/my';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => {
        console.log('✅ Reservations:', res);
        this.reservations = res;
      },
      error: (err) => {
        console.error('❌ Failed to load reservations', err);
        alert(err.error?.message || 'Failed to load reservations');
      }
    });
  }
}
