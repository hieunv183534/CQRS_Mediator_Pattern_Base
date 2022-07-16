import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-form-step',
  templateUrl: './form-step.component.html',
  styleUrls: ['./form-step.component.scss']
})
export class FormStepComponent implements OnInit {

  public stepCurent = 0;

  public isLoading = false;
  public formFistValue: any;
  public formSecondValue: any;
  public formThreeValue: any;
  constructor(
    private message: MessageService
  ) { }

  async ngOnInit(): Promise<void> {
    // set value default
  }

  async formCancel(): Promise<void>{
    this.stepCurent--;
  }

  async formFistSubmit(value): Promise<void> {
    this.formFistValue = value;
    this.stepCurent++;
  }

  async formSecondSubmit(value): Promise<void> {
    this.formSecondValue = value;
    this.stepCurent++;
  }

  async formThreeForm(value): Promise<void> {
    this.formThreeValue = value;
    this.isLoading = true;
    // logic api
    this.message.notiMessageSuccess('Ket thuc form 3');
    this.isLoading = false;
  }

}
