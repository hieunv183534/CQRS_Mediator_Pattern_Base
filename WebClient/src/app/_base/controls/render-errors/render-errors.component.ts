import { Component, Input } from '@angular/core';
import { FormControl, FormArray } from '@angular/forms';

@Component({
  selector: 'app-render-errors',
  templateUrl: './render-errors.component.html',
  styleUrls: ['./render-errors.component.scss']
})
export class RenderErrorsComponent {

  @Input() control: FormControl | any;

  constructor(){

  }
}
