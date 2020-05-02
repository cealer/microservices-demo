import { Injectable, OnInit } from '@angular/core';
import { WebSocketSubject, webSocket } from 'rxjs/webSocket';
import { Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class WsRecordService {

  myWebSocket: WebSocketSubject<any>;

  // Observable string sources
  private recordCreatedSource = new Subject<any>();

  // Observable string streams
  recordCreated$ = this.recordCreatedSource.asObservable();

  constructor() { }

  connect() {
    this.myWebSocket = webSocket(`ws://${environment.ws_uri}:${environment.ws_port}`);
  }

  subscribe() {
    this.myWebSocket.subscribe(msg => {
      this.refreshRecord(msg);
    });
  }

  predictedSalary(predictedSalaryEvent) {
    this.myWebSocket.next(predictedSalaryEvent);
  }

  refreshRecord(record: any) {
    this.recordCreatedSource.next(record);
  }

}
