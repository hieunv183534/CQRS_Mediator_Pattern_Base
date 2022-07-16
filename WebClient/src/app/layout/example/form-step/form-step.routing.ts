import { FormStepComponent } from './form-step.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: FormStepComponent },
];

export const FormStepRoutes = RouterModule.forChild(routes);
