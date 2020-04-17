import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/views/profile/profile.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { SalaryPrediction } from '../../models/salary-prediction.model';
import { SalaryPredictionResponse } from '../../models/salary-prediction-response.model';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {

  constructor(private profileService: ProfileService, private formBuilder: FormBuilder) { }

  itemForm: FormGroup;

  ngOnInit(): void {
    this.setItem();
  }

  setItem() {
    this.itemForm = this.formBuilder.group(
      {
        yearExperience: new FormControl(0, [Validators.required]),
        salary: new FormControl(0)
      }
    );
  }

  get yearExperience() {
    return this.itemForm.get('yearExperience').value;
  }

  setSalary(salaryValue: number) {
    this.itemForm.controls.salary.setValue(salaryValue);
  }

  predictSalary() {
    const requestSalary = new SalaryPrediction(this.yearExperience);
    this.profileService.PredictionSalarayRequest(requestSalary)
      .subscribe((request: SalaryPredictionResponse) => {
        this.setSalary(request.result);
      });
  }

}
