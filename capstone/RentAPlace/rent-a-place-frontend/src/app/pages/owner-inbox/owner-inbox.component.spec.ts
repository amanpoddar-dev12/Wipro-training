import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerInboxComponent } from './owner-inbox.component';

describe('OwnerInboxComponent', () => {
  let component: OwnerInboxComponent;
  let fixture: ComponentFixture<OwnerInboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerInboxComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnerInboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
