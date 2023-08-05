import { TestBed } from '@angular/core/testing';

import { PepolsService } from './pepols.service';

describe('PepolsService', () => {
  let service: PepolsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PepolsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
