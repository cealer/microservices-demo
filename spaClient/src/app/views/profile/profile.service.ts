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

  get SalaryPredicionRequestURI(): string {
    return `${this.salaryPredictionURI}/predictions`;
  }

  constructor(private httpClient: HttpClient) { }

  PredictionSalarayRequest(salaryPrediction: SalaryPrediction) {
    return this.httpClient.post(this.SalaryPredicionRequestURI, salaryPrediction);
  }

}
