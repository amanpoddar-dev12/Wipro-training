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
  images: string[] = [];
  apiUrl = 'http://localhost:5101/api/properties';

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

 ngOnInit(): void {
  const id = this.route.snapshot.paramMap.get('id');
  if (id) {
    this.http.get(`${this.apiUrl}/${id}`).subscribe({
      next: (res: any) => {
        this.property = res;

       
        if (Array.isArray(this.property.images)) {
          this.images = this.property.images.map((img: string) => img.trim());
        } else if (typeof this.property.images === 'string') {
          this.images = this.property.images
            .split(',')
            .map((img: string) => img.trim())
            .filter((img: string) => img.length > 0);
        } else {
          this.images = [];
        }

        console.log("Images prepared for carousel:", this.images);
      },
      error: (err) => console.error('Failed to load property', err)
    });
  }
}



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
}
