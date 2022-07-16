import { BaocaoViewDialogComponent } from './../../baocao-view-dialog/baocao-view-dialog.component';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { BCCPREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery, ReportBiApi } from 'src/app/_shared/report-api.services';

@Component({
  selector: 'app-baocao-data-test-dialog',
  templateUrl: './baocao-data-test-dialog.component.html',
  styleUrls: ['./baocao-data-test-dialog.component.scss']
})
export class BaocaoDataTestDialogComponent implements OnInit {

  @Input() reportCode: string;
  @Input() reportParams: string;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public isSubmit = false;
  public isLoading = false;
  public myForm: FormGroup;
  public viewDataSet: any;
  public isLoadFirstIframe = true;
  public reportViewUrl: string;
  constructor(private fb: FormBuilder,
    private dialogService: DialogService,
    private reportBiApi: ReportBiApi) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      reportParams: [this.reportParams, ValidatorExtension.required()],
    });
  }

  async viewData(): Promise<void> {
    this.viewDataSet = "";
    const body = new BCCPREPORTDomainApplicationDanhMucReportManagerQueriesTestDataQuery();
    body.init({
      reportCode: this.reportCode,
      reportParams: this.myForm.get('reportParams').value
    });
    const rs = await this.reportBiApi.testDataSet(body).toPromise();
    if (rs.success) {
      this.reportViewUrl = null;
      this.viewDataSet = JSON.parse(rs.result);
    }
  }

  async viewReport(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem báo cáo';
      option.size = DialogSize.full;
      option.component = BaocaoViewDialogComponent;
      option.inputs = {
        reportCode: this.reportCode,
        reportParams: this.myForm.get('reportParams').value,
        mode: DialogMode.view
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async printReport(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'In báo cáo';
      option.size = DialogSize.full;
      option.component = BaocaoViewDialogComponent;
      option.inputs = {
        reportCode: this.reportCode,
        reportParams: this.myForm.get('reportParams').value,
        mode: DialogMode.print,
        autoCloseDone: true
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async dowloadReport(type: any): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Tải báo cáo';
      option.size = DialogSize.full;
      option.component = BaocaoViewDialogComponent;
      option.inputs = {
        reportCode: this.reportCode,
        reportParams: this.myForm.get('reportParams').value,
        mode: DialogMode.dowload,
        typeDowload: type,
        fileNameDowload: 'baocao08',
        autoCloseDone: true
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }
}