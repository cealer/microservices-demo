import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ProfileService } from 'src/app/views/profile/profile.service';
import { Record } from '../../models/record.model';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { WsRecordService } from '../../service/ws-record.service';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.scss']
})
export class RecordsComponent implements OnInit {

  displayedColumns: string[] = ['uri', 'description'];
  dataSource;
  records: Record[] = [];

  constructor(private profileService: ProfileService, private wsRecordService: WsRecordService) {
    this.wsRecordService.subscribe();
    this.wsRecordService.recordCreated$.subscribe(recordCreated => {
      this.records.push(recordCreated);
      console.log(this.records);
      this.dataSource = [...this.records];
      console.log(this.dataSource);
    });
  }

  ngOnInit(): void {
    this.profileService.GetAllRecords(0, 10).subscribe((records: Record[]) => {
      this.dataSource = records;
    });
  }

}
