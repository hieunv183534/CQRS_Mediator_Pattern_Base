import { PrinterService } from './../../../../_shared/services/printer.service';
import { UserService } from './../../../../_shared/services/user.service';
import { DialogService } from './../../../../_base/servicers/dialog.service';
import { MessageService } from './../../../../_base/servicers/message.service';
import { FormBuilder } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DialogMode } from 'src/app/_base/servicers/dialog.service';
import { DanhMucReportManagerPrinterGetPagingPrinterQuery, DanhMucReportManagerPrinterGetPagingQuery, DimReportManagerPrinterApi } from 'src/app/_shared/bccp-api.services';
import { environment } from 'src/environments/environment';
import { SettingService } from 'src/app/_shared/services/setting.service';

@Component({
  selector: 'app-baocao-view-dialog',
  templateUrl: './baocao-view-dialog.component.html',
  styleUrls: ['./baocao-view-dialog.component.scss']
})
export class BaocaoViewDialogComponent implements OnInit {

  @Input() reportCode: string;
  @Input() reportParams: string;
  @Input() mode: string;
  @Input() autoCloseDone: boolean;
  @Input() typeDowload: number;
  @Input() fileNameDowload: string;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public isSubmit = false;
  public isLoading = true;
  public isLoadFirstIframe = false;
  public reportViewUrl: string;
  private printHide = false;

  public nameReport = this.generateQuickGuid();

  constructor(
    public fb: FormBuilder,
    private settingService: SettingService,
    public messageService: MessageService,
    public dialogService: DialogService,
    public userService: UserService,
    public printerService: PrinterService,
    public dimReportManagerPrinter: DimReportManagerPrinterApi
  ) { }

  async ngOnInit() {
    switch (this.mode) {
      case DialogMode.dowload:
        location.href = `${this.settingService.data.reportApi}/api/ReportBi/Export?ReportCode=${this.reportCode}&FileName=${this.fileNameDowload}&Type=${this.typeDowload}&ReportParams=${this.reportParams}&access_token=${this.userService.authorizationHeaderValue.replace('Bearer ','')}`;
        this.closeDialog();
        break;
      case DialogMode.print:
        let printerData: any[] = await this.getPrinterName();
        if (printerData && printerData.length > 0) {
          if (printerData.length == 1 && (!printerData[0].ip || printerData[0].ip === '[]' || printerData[0].ip === '[""]')) {
            this.printDive(printerData[0]);
            this.closeDialog();
          } else {
            let myIp: string;
            try {
              myIp = await this.printerService.getIp();
            } catch (error) {
              this.messageService.notiMessageError('Bi???u m???u n??y ???? ???????c c???u h??nh in t??? ?????ng cho thi???t b??? c???a m??y b???n.Nh??ng M??y T??nh c???a B???n ch??a c??i ?????t ???ng d???ng KT1 M??y In');
              return;
            }

            let printDataItem = printerData.find(x => !x.ip);
            let printDataItem2 = printerData.find(x => x.ip && JSON.parse(x.ip).some(s => s === myIp))
            if (printDataItem2 != null) {
              printDataItem = printDataItem2;
            }
            if (!printDataItem) {
              this.reportViewUrl = `${this.settingService.data.reportApi}/api/ReportBi/View?ReportCode=${this.reportCode}&ReportParams=${this.reportParams}`;
              this.messageService.notiMessageError('IP c???a b???n ch??a ???????c c???u h??nh in t??? ?????ng v???i bi???u m???u n??y');
              return;
            }

            this.printDive(printDataItem);

            this.closeDialog();
          }
        } else {
          this.reportViewUrl = `${this.settingService.data.reportApi}/api/ReportBi/View?ReportCode=${this.reportCode}&ReportParams=${this.reportParams}`;
        }
        break;
      default:
        this.reportViewUrl = `${this.settingService.data.reportApi}/api/ReportBi/View?ReportCode=${this.reportCode}&ReportParams=${this.reportParams}`;
        break;
    }
  }

  generateQuickGuid() {
    return Math.random().toString(36).substring(2, 15) +
      Math.random().toString(36).substring(2, 15);
  }

  async printReportLoading(): Promise<void> {
    if (!this.isLoadFirstIframe && this.mode === DialogMode.print) {
      try {
        setTimeout(() => {
          (document.getElementById(this.nameReport) as any).contentWindow.print();
        }, 300);
      } catch (error) {

      }
    }
    this.isLoadFirstIframe = false;
    this.isLoading = false;
  }

  async printReport(): Promise<void> {
    (document.getElementById(this.nameReport) as any).contentWindow.print();
  }

  async printDive(item: any) {
    try {
      this.printerService.printToPrinter({
        url: `${this.settingService.data.reportApi}/api/ReportBi/View?ReportCode=${this.reportCode}&ReportParams=${this.reportParams}&access_token=${this.userService.authorizationHeaderValue.replace('Bearer ','')}`,
        printerName: item.printerName,
        optionPrint: item.optionPrint
      });
    } catch (error) {
      this.messageService.notiMessageError('Kh??ng k???t n???i ???????c t???i ???ng d???ng KT1 M??y In. Vui l??ng b???t l???i ???ng d???ng KT1 M??y In');
    }
  }

  async dowloadReport(type: number): Promise<void> {
    location.href = `${this.settingService.data.reportApi}/api/ReportBi/Export?ReportCode=${this.reportCode}&FileName=${this.fileNameDowload}&Type=${type}&ReportParams=${this.reportParams}&access_token=${this.userService.authorizationHeaderValue.replace('Bearer ','')}`;
  }

  async getPrinterName(): Promise<any[]> {
    const params = new DanhMucReportManagerPrinterGetPagingPrinterQuery({
      posCode: this.userService.userInfo.postCode,
      reportCode: this.reportCode,
      loadMore: true
    });

    const rs = await this.dimReportManagerPrinter.getPagingPrinter(params).toPromise();

    if (rs.success) {
      return rs.result.data;
    }
    else {
      this.messageService.notiMessageError(rs.error);
    }

    return null;
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }
}
