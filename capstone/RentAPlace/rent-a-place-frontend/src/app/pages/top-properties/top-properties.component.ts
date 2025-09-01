import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SelectedPropertiesService } from '../../services/selected-properties.service';

@Component({
  selector: 'app-top-properties',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './top-properties.component.html',
  styleUrls: ['./top-properties.component.css']
})
export class TopPropertiesComponent implements OnInit {
  topRatedByCategory: any[] = [];
  apiUrl = 'http://localhost:5101/api/properties';

  constructor(private http: HttpClient, private selectedService: SelectedPropertiesService) {}

selectProperty(property: any) {
  this.selectedService.addProperty(property);
  alert(`${property.title} added to selected list!`);
}

  ngOnInit(): void {
    this.http.get<any[]>(`${this.apiUrl}/top-rated`).subscribe({
      next: (res) => (this.topRatedByCategory = res),
      error: (err) => console.error('Failed to load top-rated', err)
    });
  }
}
