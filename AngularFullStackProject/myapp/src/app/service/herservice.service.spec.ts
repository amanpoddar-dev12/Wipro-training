import { TestBed } from '@angular/core/testing';

import { HerserviceService } from './herservice.service';

describe('HerserviceService', () => {
  let service: HerserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HerserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
