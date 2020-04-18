import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { SalaryPrediction } from 'src/app/shared/models/salary-prediction.model';
import { SalaryPredictionResponse } from 'src/app/shared/models/salary-prediction-response.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private salaryPredictionURI = environment.predict_salary_uri;
  private historyURI = environment.history_uri;

  get SalaryPredicionRequestURI(): string {
    return `${this.salaryPredictionURI}/predictions`;
  }

  get RecordsURI(): string {
    return `${this.historyURI}/api/v1/records`;
  }

  constructor(private httpClient: HttpClient) { }

  PredictionSalarayRequest(salaryPrediction: SalaryPrediction) {
    return this.httpClient.post(this.SalaryPredicionRequestURI, salaryPrediction);
  }

  GetAllRecords(skip: number = 0, limit: number = 10) {
    return this.httpClient.get(`${this.RecordsURI}?skip=${skip}&limit=${limit}`);
  }

}
