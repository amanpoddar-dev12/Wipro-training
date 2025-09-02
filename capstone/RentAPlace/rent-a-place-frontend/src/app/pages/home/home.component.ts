import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterLink } from '@angular/router';
import { TopPropertiesComponent } from '../top-properties/top-properties.component';
import { SelectedPropertiesService } from '../../services/selected-properties.service';
import { NotificationService } from '../../services/notification.service';
import { NotificationComponent } from '../../shared/notification/notification.component';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink,TopPropertiesComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
  
export class HomeComponent implements OnInit {
  properties: any[] = [];
  topRatedByCategory: any[] = [];
  apiUrl = 'http://localhost:5101/api/properties';
   @ViewChild('notifier') notifier!: NotificationComponent;
  constructor(private http: HttpClient, private selectedService: SelectedPropertiesService,private notify: NotificationService) {}

selectProperty(property: any) {
  this.selectedService.addProperty(property);
   this.notify.show(`${property.title} added to selected list✅!`, 'success');
}
   showTop = false;
  
  toggleTop() {
    this.showTop = !this.showTop;
  }
  ngOnInit(): void {
    this.http.get<any[]>(this.apiUrl).subscribe({
      next: (res) => (this.properties = res),
      
      error: (err) => console.error('Failed to load properties', err)
    });
     this.http.get<any[]>(`${this.apiUrl}/top-rated`).subscribe({
    next: (res) => (this.topRatedByCategory = res),
    error: (err) => console.error('Failed to load top-rated', err)
  });
  }
  
}



