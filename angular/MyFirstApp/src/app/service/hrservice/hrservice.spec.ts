import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Hrservice } from './hrservice';

describe('Hrservice', () => {
  let component: Hrservice;
  let fixture: ComponentFixture<Hrservice>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Hrservice]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Hrservice);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
