import { UserService } from 'src/app/_shared/services/user.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
// import { PermissionsClient } from '../_shared/services/identity-api';
// import { AuthorizeService } from 'src/api-authorization/authorize.service';
// import { filter, mergeMap } from 'rxjs/operators';
// import { NgxPermissionsService } from 'ngx-permissions';
// import { SignalRHubService } from '../_base/services/signalr.service';

declare let App: any;
declare let $: any;
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class LayoutComponent implements OnInit {

  isInit = false;
  isDasboard: boolean = false;

  constructor(
    private userService: UserService,
    // private permissionsClient: PermissionsClient,
    // private ngxPs: NgxPermissionsService,
    // signalRHubService: SignalRHubService
  ) { }

  ngOnInit(): void {
    if(this.userService.userInfo.userName.startsWith('bandoso')){
    // if (this.userService.userInfo.userName.startsWith('100901')) {
      this.isDasboard = true;
      $('body').toggleClass('sidebar-xs').removeClass('sidebar-mobile-main');
    }
    // this.authorizeService.isAuthenticated()
    //   .pipe(filter(x => !!x), mergeMap(() => this.permissionsClient.getPermissionsOfUser()))
    //   .pipe(filter(() => !this.hasPerm))
    //   .subscribe(p => {
    //     this.ngxPs.loadPermissions(p.map(x => x.name));
    //     setTimeout(() => {
    //       App.initCore();
    //     }, 200);
    //     this.isInit = true;
    //   });
  }

  // get hasPerm() {
  //   return Object.keys(this.ngxPs.getPermissions()).length !== 0 || this.isInit;
  // }

}
