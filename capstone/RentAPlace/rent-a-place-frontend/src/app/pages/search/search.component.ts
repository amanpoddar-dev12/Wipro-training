import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SelectedPropertiesService } from '../../services/selected-properties.service';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [FormsModule, HttpClientModule, CommonModule,RouterLink],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  location = '';
  type = '';
  features = '';
  checkIn = '';
  checkOut = '';

  results: any[] = [];
  apiUrl = 'http://localhost:5101/api/properties/search';

  constructor(private http: HttpClient,private selectedService: SelectedPropertiesService) {}
  selectProperty(property: any) {
  this.selectedService.addProperty(property);
  alert(`${property.title} added to selected list!`);
}
  search() {
    let params: string[] = [];

    if (this.location) params.push(`location=${this.location}`);
    if (this.type) params.push(`type=${this.type}`);
    if (this.features) params.push(`features=${this.features}`);
    if (this.checkIn) params.push(`checkIn=${this.checkIn}`);
    if (this.checkOut) params.push(`checkOut=${this.checkOut}`);

    const query = params.length ? '?' + params.join('&') : '';

    this.http.get<any[]>(`${this.apiUrl}${query}`).subscribe({
      next: (res) => (this.results = res),
      error: (err) => console.error('Search failed', err)
    });
  }
}
