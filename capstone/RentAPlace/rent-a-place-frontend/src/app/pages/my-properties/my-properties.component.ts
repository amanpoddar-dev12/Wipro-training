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
  selectedFiles: File[] = [];
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


 onFileSelected(event: any) {
  this.selectedFiles = Array.from(event.target.files);
}

uploadImages(): Promise<string[]> {
  return new Promise((resolve, reject) => {
    if (this.selectedFiles.length === 0) return resolve([]);

    const formData = new FormData();
    this.selectedFiles.forEach(file => formData.append('files', file));

    this.http.post<string[]>(`${this.apiUrl}/upload-images`, formData, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => resolve(res),
      error: (err) => reject(err)
    });
  });
}

async addProperty() {
  try {
    const uploadedUrls = await this.uploadImages();
    this.newProperty.images = uploadedUrls.join(',');

    this.http.post(this.apiUrl, this.newProperty, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Property added!');
        this.newProperty = { title: '', description: '', type: '', location: '', features: '', pricePerNight: 0, images: '' };
        this.selectedFiles = [];
        this.loadMyProperties();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  } catch (err) {
    alert('❌ Image upload failed.');
  }
}

  editProperty(prop: any) {
    this.editingProperty = { ...prop };
  }

  async updateProperty() {
  try {
    const uploadedUrls = await this.uploadEditImages();

    if (uploadedUrls.length > 0) {
     
      this.editingProperty.images = uploadedUrls.join(',');

    }

    this.http.put(`${this.apiUrl}/${this.editingProperty.propertyId}`, this.editingProperty, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: () => {
        alert('✅ Property updated with new images!');
        this.editingProperty = null;
        this.editSelectedFiles = [];
        this.loadMyProperties();
      },
      error: (err) => alert('❌ Failed: ' + (err.error?.message || err.message))
    });
  } catch (err) {
    alert('❌ Image upload failed.');
  }
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
  editSelectedFiles: File[] = [];

onEditFilesSelected(event: any) {
  this.editSelectedFiles = Array.from(event.target.files);
}

uploadEditImages(): Promise<string[]> {
  return new Promise((resolve, reject) => {
    if (this.editSelectedFiles.length === 0) return resolve([]);

    const formData = new FormData();
    this.editSelectedFiles.forEach(file => formData.append('files', file));

    this.http.post<string[]>(`${this.apiUrl}/upload-images`, formData, {
      headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
    }).subscribe({
      next: (res) => resolve(res),
      error: (err) => reject(err)
    });
  });
}


  
}
