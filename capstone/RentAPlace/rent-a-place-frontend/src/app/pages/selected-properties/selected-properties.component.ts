import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SelectedPropertiesService } from '../../services/selected-properties.service';

@Component({
  selector: 'app-selected-properties',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './selected-properties.component.html',
  styleUrls: ['./selected-properties.component.css']
})
export class SelectedPropertiesComponent implements OnInit {
  selected: any[] = [];

  constructor(private selectedService: SelectedPropertiesService) {}
 
  
  
  ngOnInit(): void {
    this.selected = this.selectedService.getProperties();
  }

  remove(id: number) {
    this.selectedService.removeProperty(id);
    this.selected = this.selectedService.getProperties();
  }
}
