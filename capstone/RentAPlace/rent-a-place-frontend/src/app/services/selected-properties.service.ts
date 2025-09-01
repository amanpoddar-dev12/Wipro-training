import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SelectedPropertiesService {
  private selected: any[] = [];

  addProperty(property: any) {
    if (!this.selected.find(p => p.propertyId === property.propertyId)) {
      this.selected.push(property);
    }
  }

  removeProperty(id: number) {
    this.selected = this.selected.filter(p => p.propertyId !== id);
  }

  getProperties() {
    return this.selected;
  }
}
