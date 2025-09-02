import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-my-properties',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './my-properties.component.html',
  styleUrls: ['./my-properties.component.css']
})
export class MyPropertiesComponent implements OnInit {
  properties: any[] = [];
  newProperty: any = {
    title: '',
    description: '',
    type: '',
    location: '',
    features: '',
    pricePerNight: 0,
    images: ''
  };
  editingProperty: any = null;
  apiUrl = 'http://localhost:5101/api/properties';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadMyProperties();
  }

  loadMyProperties() {
  this.http.get<any[]>(`${this.apiUrl}/my`, {
    headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
  }).subscribe({
    next: (res) => {
      console.log("✅ My properties:", res);
      this.properties = res;
    },
    error: (err) => {
      console.error("❌ Failed to load properties", err);
      alert(err.error?.message || 'Failed to load properties');
    }
  });
}


  addProperty() {
    this.http.post(this.apiUrl, this.newProperty, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Property added!');
        this.newProperty = { title: '', description: '', type: '', location: '', features: '', pricePerNight: 0, images: '' };
        this.loadMyProperties();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  }

  editProperty(prop: any) {
    this.editingProperty = { ...prop };
  }

  updateProperty() {
    this.http.put(`${this.apiUrl}/${this.editingProperty.propertyId}`, this.editingProperty, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Property updated!');
        this.editingProperty = null;
        this.loadMyProperties();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  }

  deleteProperty(id: number) {
    if (!confirm('Are you sure?')) return;
    this.http.delete(`${this.apiUrl}/${id}`, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Property deleted!');
        this.loadMyProperties();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  }
}
