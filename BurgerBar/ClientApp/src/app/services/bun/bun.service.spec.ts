import { TestBed } from '@angular/core/testing';

import { BunService } from './bun.service';

describe('BunService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BunService = TestBed.get(BunService);
    expect(service).toBeTruthy();
  });
});
