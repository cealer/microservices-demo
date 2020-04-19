import { TestBed } from '@angular/core/testing';

import { WsRecordService } from './ws-record.service';

describe('WsRecordService', () => {
  let service: WsRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WsRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
