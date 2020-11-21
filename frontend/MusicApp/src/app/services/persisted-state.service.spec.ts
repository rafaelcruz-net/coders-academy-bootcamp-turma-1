import { TestBed } from '@angular/core/testing';

import { PersistedStateService } from './persisted-state.service';

describe('PersistedStateService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PersistedStateService = TestBed.get(PersistedStateService);
    expect(service).toBeTruthy();
  });
});
