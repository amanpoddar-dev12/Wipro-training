import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedPropertiesComponent } from './selected-properties.component';

describe('SelectedPropertiesComponent', () => {
  let component: SelectedPropertiesComponent;
  let fixture: ComponentFixture<SelectedPropertiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectedPropertiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectedPropertiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
