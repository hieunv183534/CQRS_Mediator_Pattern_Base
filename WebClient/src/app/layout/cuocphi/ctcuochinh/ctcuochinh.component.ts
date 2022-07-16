import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cuocphi-cauhinhvung',
  templateUrl: './ctcuochinh.component.html',
  styleUrls: ['./ctcuochinh.component.scss']
})
export class CtcuochinhComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleId') ruleId: number;
  @Input('stepId') stepId: number;

  @Output('onClose') onClose = new EventEmitter<any>();
  public checked = false;
  public loading = false;
  public isLoading = false; 

  constructor() { }

  ngOnInit() {
  }
  async closeDialog(): Promise<void> {    
    this.onClose.emit(null);
  }
}
