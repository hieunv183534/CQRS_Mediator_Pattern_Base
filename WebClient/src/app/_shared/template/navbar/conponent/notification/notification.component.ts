import { ActivatedRoute, Router } from '@angular/router';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import {
  NotificationApi, TraCuuItemApi, TraCuuItemGetToanTrinhPagingQuery,
} from 'src/app/_shared/bccp-api.services';
import { PagingModel } from 'src/app/_base/models/response-model';
import { MessageService } from '../../../../../_base/servicers/message.service';
import {
  SupportNotificationGetPagingQuery,
  SupportNotificationNotificationGetPagingQuery,
  SupportNotificationNotificationSeenCommand
} from '../../../../bccp-api.services';
import { RealTimeService } from '../../../../services/real-time.service';
import { DialogService } from '../../../../../_base/servicers/dialog.service';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit, OnDestroy {

  listOfData: any[] = [];
  isLoading = false;
  isLoadMore = false;
  public pageChange$ = new BehaviorSubject(1);
  private pageChange: any;

  constructor(
    private notificationApi: NotificationApi,
    private messageService: MessageService,
    private dialogService: DialogService,
    private realTimeService: RealTimeService,
    private traCuuItemApi: TraCuuItemApi,
    private rt: Router
  ) {
  }

  ngOnInit(): void {
    // this.pageChange = this.pageChange$
    //   .asObservable()
    //   .pipe(debounceTime(500)).subscribe(page => {
    //     console.log('get paging ne nha');
    //   });
    // this.getData();
    // this.realTimeService.broadcastMessage.subscribe(message => {
    //   this.listOfData = [message, ... this.listOfData];
    //   this.messageService.notiMessageSuccess(message?.title);
    //   console.log(message);
    // });
    this.getData();
  }

  async getData(paging: PagingModel = { page: 1, size: 50, loadMore: true, order: { id: false } }): Promise<void> {

    const where = { and: [] };
    const params = new TraCuuItemGetToanTrinhPagingQuery({
      ...paging,
      type: 1
    });

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    if (paging.page === 1) {
      this.listOfData = [];
      this.isLoading = false;
    }

    if (this.isLoading == null) {
      return;//no data
    }

    this.isLoading = true;
    const rs = await this.traCuuItemApi.getToanTrinhPaging(params).toPromise();
    if (rs.success) {
      if (rs.result.paging.count <= rs.result.paging.size) {
        this.isLoading = null;
      }
      this.listOfData = [...this.listOfData, ...rs.result.data.map(x => {
        const title = 'Cảnh báo';
        let description = '';
        if (x.conLaiToanTrinh > 0) {
          description = `Mã bưu gửi: ${x.itemCode} còn ${x.conLaiToanTrinh} giờ sẽ chậm toàn trình`;
        } else {
          description = `Mã bưu gửi: ${x.itemCode} đã chậm ${x.conLaiToanTrinh} giờ mã vẫn chưa phát`;
        }
        return {
          id: x.itemCode,
          title: title,
          description: description
        };
      })];
      //this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  // @HostListener('scroll', ['$event'])
  onScroll(event: any): void {
    // visible height + pixel scrolled >= total height
    // if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
    //   console.log('End');
    //   this.pageChange.next(1);
    // }
  }

  // async getData(paging: PagingModel = {page: 1, size: 10}): Promise<void> {
  //   const params = new SupportNotificationNotificationGetPagingQuery({
  //     ...paging
  //   });

  //   this.isLoading = true;
  //   const rs = await this.notificationApi.getPagingNotification(params).toPromise();
  //   if (rs.success) {
  //     this.listOfData = rs.result.data;
  //   } else {
  //     this.messageService.notiMessageError(rs.error);
  //   }

  //   this.isLoading = false;
  // }

  ngOnDestroy(): void {
    //this.pageChange.unsubscribe();
  }

  async seen(item: any): Promise<void> {
    // this.messageService.notiMessageSuccess(item.description);
    // if (item?.readTime) {
    //   return;
    // }
    // const params = new SupportNotificationNotificationSeenCommand({
    //   id: item.id
    // });
    // const rsSeen = await this.notificationApi.seen(params).toPromise();
    // if (rsSeen.success) {
    //   for (const notify of this.listOfData) {
    //     if (notify.id === item.id) {
    //       notify.readTime = Date().toString();
    //     }
    //   }
    //   this.listOfData = [...this.listOfData];
    // }
    this.rt.navigate(['/tracuu', '/tracuubuugui'], { queryParams: { itemCode: item } });
  }
}
