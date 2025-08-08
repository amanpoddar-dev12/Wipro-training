import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileOpsComponent } from './file-ops.component';

describe('FileOpsComponent', () => {
  let component: FileOpsComponent;
  let fixture: ComponentFixture<FileOpsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FileOpsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FileOpsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
