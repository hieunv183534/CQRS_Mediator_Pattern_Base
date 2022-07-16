import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/_shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService: UserService,
    private ar: ActivatedRoute) { }

  ngOnInit() {
    const url = this.ar.snapshot.queryParams.redirect;
    localStorage.setItem('loginCallBack', url);
    let loginCount = localStorage.getItem('loginCount');
    if (!loginCount) {
      loginCount = '0';
    }
    loginCount = (parseInt(loginCount) + 1) + '';
    localStorage.setItem('loginCount', loginCount)
    
    if (loginCount === '3') {
      localStorage.removeItem('loginCallBack');
      localStorage.removeItem('loginCount');
      this.authService.logout();
      return;
    }
    this.authService.login();
  }

}
