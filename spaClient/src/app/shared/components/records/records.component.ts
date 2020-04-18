import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/views/profile/profile.service';
import { Record } from '../../models/record.model';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.scss']
})
export class RecordsComponent implements OnInit {

  displayedColumns: string[] = ['uri', 'description'];
  dataSource;

  constructor(private profileService: ProfileService) { }

  ngOnInit(): void {
    this.profileService.GetAllRecords(0, 10).subscribe((records: Record) => {
      this.dataSource = records;
    });
  }

}
