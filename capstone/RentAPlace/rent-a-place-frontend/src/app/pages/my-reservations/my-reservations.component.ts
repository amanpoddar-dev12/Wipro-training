import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-my-reservations',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './my-reservations.component.html',
  styleUrls: ['./my-reservations.component.css']
})
export class MyReservationsComponent implements OnInit {
  reservations: any[] = [];
  apiUrl = 'http://localhost:5101/api/reservations/my';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (res) => (this.reservations = res),
      error: (err) => console.error('Failed to load reservations', err)
    });
  }
}
