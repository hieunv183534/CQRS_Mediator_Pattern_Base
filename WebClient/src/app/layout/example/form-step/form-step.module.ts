import { FormStepThreeComponent } from './form-step-three/form-step-three.component';
import { FormStepSecondComponent } from './form-step-second/form-step-second.component';
import { FormStepFirstComponent } from './form-step-first/form-step-first.component';
import { FormStepRoutes } from './form-step.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormStepComponent } from './form-step.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzStepsModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzStepsModule, // Thêm dòng này để import step module
    FormStepRoutes
  ],
  declarations: [
    FormStepComponent,
    FormStepFirstComponent, // Import Component 1
    FormStepSecondComponent, // Import Component 2
    FormStepThreeComponent // Import Component 3
  ]
})
export class FormStepModule { }
