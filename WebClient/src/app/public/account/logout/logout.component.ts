import { UserApi } from 'src/app/_shared/bccp-api.services';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { UserService } from 'src/app/_shared/services/user.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(private authService: UserService, private userApi: UserApi) { }

  ngOnInit() {
    localStorage.removeItem('loginCallBack');
    localStorage.removeItem('loginCount');
    this.userApi.logOut().toPromise().then(x => {
      this.authService.logout();
    });
  }

}
