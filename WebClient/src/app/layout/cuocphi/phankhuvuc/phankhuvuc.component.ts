import { Component, OnInit, Input } from '@angular/core';
import { MessageService } from 'src/app/_base/servicers/message.service';

@Component({
  selector: 'app-cuocphi-phankhuvuc',
  templateUrl: './phankhuvuc.component.html',
  styleUrls: ['./phankhuvuc.component.scss']
})
export class PhanKhuVucComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleId') ruleId: number;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleCode') ruleCode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('serviceCode') serviceCode: string;
  public stepCurent = 0;
  public isLoading = false;
  public lstProvinceCode: string[] = [];
  public lstDistrictCode: string[] = [];
  constructor(
    private message: MessageService
  ) { }

  async ngOnInit(): Promise<void> {
    // set value default
  }
  async preStep(): Promise<void>{
    this.stepCurent--;
  }

  async nextHuyen(value): Promise<void> {
    this.lstProvinceCode = value;
    this.stepCurent++;
  }

  async nextBuuCuc(value): Promise<void> {
    this.lstDistrictCode = value;
    this.stepCurent++;
  }

}
