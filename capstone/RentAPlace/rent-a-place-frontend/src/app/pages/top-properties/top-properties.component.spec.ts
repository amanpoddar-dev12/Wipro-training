import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopPropertiesComponent } from './top-properties.component';

describe('TopPropertiesComponent', () => {
  let component: TopPropertiesComponent;
  let fixture: ComponentFixture<TopPropertiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopPropertiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopPropertiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
