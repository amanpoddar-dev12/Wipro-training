import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-property-details',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.css']
})
export class PropertyDetailsComponent implements OnInit {
  property: any;
  apiUrl = 'http://localhost:5101/api/properties';

  constructor(private route: ActivatedRoute, private http: HttpClient) {}
reserveProperty() {
  this.http.post('http://localhost:5101/api/reservations', {
    propertyId: this.property.propertyId,
    checkIn: '2025-09-10',
    checkOut: '2025-09-15'
  }).subscribe({
    next: () => alert('✅ Reservation created!'),
    error: (err) => alert('❌ Failed: ' + (err.error || err.message))
  });
}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.http.get(`${this.apiUrl}/${id}`).subscribe({
        next: (res) => (this.property = res),
        error: (err) => console.error('Failed to load property', err)
      });
    }
  }
}
