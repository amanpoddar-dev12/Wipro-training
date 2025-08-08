import { TestBed } from '@angular/core/testing';

import { Dataservice } from './dataservice';

describe('Dataservice', () => {
  let service: Dataservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Dataservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
