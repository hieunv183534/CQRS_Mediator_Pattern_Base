import { SettingService } from './../../../_shared/services/setting.service';
import {
  Component,
  OnInit,
  ViewEncapsulation,
  Input,
  ElementRef,
  AfterViewInit,
  OnChanges
} from '@angular/core';

declare var $;
@Component({
  selector: 'img-server',
  templateUrl: './img-server.component.html',
  styleUrls: ['./img-server.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ImgServerComponent implements OnInit, OnChanges, AfterViewInit {
  @Input() src: any;
  @Input() alt: any;
  @Input() class: any;
  public isLoad = false;
  public srcloading: any;
  constructor(
    private settingService: SettingService,
    private el: ElementRef
    ) { }

  ngOnInit() {
    this.startLoading();
  }

  ngOnChanges() {
    if (this.isLoad) {
      this.isLoad = false;
      $(this.el.nativeElement).addClass(this.class);
      this.startLoading();
      this.endLoading();
    }
  }

  ngAfterViewInit() {
    this.endLoading();
  }

  startLoading() {
    this.srcloading = `${
      this.settingService.data.urlApi
      }/api/file/dowload?url=${this.src}&w=${10}&h=${10}`;
  }

  endLoading() {
    const outside = this;
    setTimeout(() => {
      const img = outside.el.nativeElement;
      const w = $(img).width();
      const h = $(img).height();

      this.src = `${
        this.settingService.data.urlApi
        }/api/file/dowload?url=${outside.src}&w=${w}&h=${h}`;
      $(outside.el.nativeElement).removeClass(outside.class);
      outside.isLoad = true;
    }, 0);
  }
}
