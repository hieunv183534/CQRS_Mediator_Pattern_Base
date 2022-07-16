import { BCCPWebApiControllersVMapRequest, VMapApi } from 'src/app/_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { BandoComponent } from '../bando/bando.component';

@Component({
  selector: 'app-vmap',
  templateUrl: './vmap.component.html',
  styleUrls: ['./vmap.component.scss']
})
export class VmapComponent implements OnInit {

  @Input() address: string;
  @Input() provinceCode: string;
  @Input() districtCode: string;
  @Input() communeCode: string;
  @Input() mode: string;
  @Output('onClose') onClose = new EventEmitter<any>();
  @Output('onSelect') onSelect = new EventEmitter<any>();

  public listOfData: any[] = [];
  public isLoading = false;

  constructor(private vMapApi: VMapApi,
              private messageService: MessageService,
              private dialogService: DialogService) { }

  ngOnInit() {
    this.getData();
  }

  async getData() {
    this.isLoading = true;
    const params = new BCCPWebApiControllersVMapRequest({
      address: this.address,
      provinceCode: this.provinceCode,
      districtCode: this.districtCode,
      communeCode: this.communeCode
    });
    const rs = await this.vMapApi.findOne(params).toPromise();
    if (rs.success) {
      this.listOfData = rs.result;
    }
    this.isLoading = false;
  }

  selectItem(item: any) {
    this.onSelect.emit(item);
  }

  openMap(item:any){
     const dialog = this.dialogService.openDialog(option => {
      option.title = 'Bản đồ';
      option.size = DialogSize.xlarge;
      option.component = BandoComponent;
      option.inputs = {
        item: {
          toLat: item.lat,
          toLong: item.long,
          toTitle: item.fullAddress
        }
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  closeDialog() {
    this.onClose.emit(null);
  }

}
