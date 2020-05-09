import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalaryPrediction } from 'src/app/shared/models/salary-prediction.model';

import { Configuration } from '../../shared/helpers/configuration.helper';
@Injectable({
  providedIn: 'root'
})
export class ProfileService {


  get SalaryPredicionRequestURI(): string {
    return `${this.configuration.ApiPredictionsUri}/predictions`;
  }

  get RecordsURI(): string {
    return `${this.configuration.ApiHistoryService}/records`;
  }

  constructor(private httpClient: HttpClient, private configuration: Configuration) { }

  PredictionSalarayRequest(salaryPrediction: SalaryPrediction) {
    return this.httpClient.post(this.SalaryPredicionRequestURI, salaryPrediction);
  }

  GetAllRecords(skip: number = 0, limit: number = 10) {
    return this.httpClient.get(`${this.RecordsURI}?skip=${skip}&limit=${limit}`);
  }

}
