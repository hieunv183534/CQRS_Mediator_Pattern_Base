import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { UserService } from '../services/user.service';

@Pipe({
  name: 'safeIframe'
})
export class SafeIframePipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer, private userService: UserService) { }

  transform(url: string): SafeResourceUrl {
    if (url.indexOf('?') !== -1) {
      url += '&access_token=' + this.userService.authorizationHeaderValue.replace('Bearer ','');
    } else {
      url += '?access_token=' + this.userService.authorizationHeaderValue.replace('Bearer ','');
    }
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

}
