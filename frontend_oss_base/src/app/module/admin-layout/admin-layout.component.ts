import {Component, OnDestroy, OnInit} from '@angular/core';

import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';
import {Constant} from 'src/app/shared/constants/constant.class';
import * as fromAuth from '../core/component/auth/redux/auth.reducer';
import * as actionAuth from '../core/component/auth/redux/auth.action';
import {ActionsSubject, Store} from '@ngrx/store';
import {filter, map} from 'rxjs/operators';
import {Subscription} from 'rxjs';
import {MenuService} from '../core/service/menu.service';
import {Menu} from '../core/model/menu.class';
import {AuthService} from '../core/service/auth.service';
import {TranslateService} from '@ngx-translate/core';
import {UserService} from '../core/service/user-service';
import {Cookie} from 'ng2-cookies/ng2-cookies';
import {PerfectScrollbarConfigInterface} from 'ngx-perfect-scrollbar';
// import {MenuLoginModel} from "../../model/auth.model";
import { AppComponent } from 'src/app/app.component';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  //styleUrls: ['./admin-layout.component.scss'],
  host: {
    '(window:resize)': 'onWindowResize($event)'
  }
})
export class AdminLayoutComponent implements OnInit, OnDestroy {


  topbarMenuActive: boolean;

    menuActive: boolean;

    staticMenuDesktopInactive: boolean;

    mobileMenuActive: boolean;

    menuClick: boolean;

    mobileTopbarActive: boolean;

    topbarRightClick: boolean;

    topbarItemClick: boolean;

    activeTopbarItem: string;

    documentClickListener: () => void;

    configActive: boolean;

    configClick: boolean;

    rightMenuActive: boolean;

    menuHoverActive = false;

    searchClick = false;

    search = false;

    currentInlineMenuKey: string;

    inlineMenuActive: any[] = [];

    inlineMenuClick: boolean;

  public config: PerfectScrollbarConfigInterface = {};

  static readonly ROUTE_DATA_PAGENAME = 'pagename';

  isCollapsed = false;
  username: string;
  name: string;
  avatarUrl: string;
  sub: Subscription;
  // menus: MenuLoginModel[] = [];
  openMenuMap: { [id: string]: boolean } = {};
  selectedMenu: Menu;
  pageName: string;
  status: string;
  // isMobile = false;
  width: number = window.innerWidth;
  height: number = window.innerHeight;
  mobileWidth = 768;
  lgWidth = 1366;
  currentUrl: string;
  slideWidth = 200;
  email: string;

  constructor(
    private route: Router,
    private activeRoute: ActivatedRoute,
    private store: Store<fromAuth.AppState>,
    private actionsSubject$: ActionsSubject,
    private menuService: MenuService,
    private authService: AuthService,
    private translate: TranslateService,
    private userService: UserService,
    public app: AppComponent,
    private primengConfig: PrimeNGConfig,
    ) {
    this.getCurrentUrl(this.route);
  }

  ngOnDestroy(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onWindowResize(event) {
    this.width = event.target.innerWidth;
    this.height = event.target.innerHeight;
    // this.isMobile = this.width < this.mobileWidth;
    if (this.width >= this.lgWidth) {
      this.slideWidth = 265;
    } else {
      this.slideWidth = 210;
    }
  }

  ngOnInit(): void {
    this.menuActive = this.isStatic() && !this.isMobile();

    const userInfo = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.USER_INFO));
    this.username = userInfo.userName;
    this.name = userInfo.name;
    this.email = userInfo.email;
    this.avatarUrl = userInfo.imageUrl != null ? userInfo.imageUrl : 'assets/image/avtDF.png';
    this.status = userInfo.status;
    this.sub = this.actionsSubject$.pipe(filter((action: any) => action.type === actionAuth.AuthActionTypes.Logout)).subscribe(action => {
    });
    // this.menus = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.MENU));
    this.route.events.pipe(
      filter(event => event instanceof NavigationEnd),
      map(() => this.getPageInfo())).subscribe((pageName: string) => {
      this.pageName = this.translate.instant(pageName);
    });
    this.pageName = this.translate.instant(this.getPageInfo());
    this.pageName = this.translate.instant(this.getPageInfo());
    // this.isMobile = this.width < this.mobileWidth;
    if (this.width >= this.lgWidth) {
      this.slideWidth = 255;
    }
  }

  // getMenuTreeByUser() {
  //   this.setOpenMenuMap(this.menus);
  // }

  private getPageInfo() {
    let child = this.activeRoute.firstChild;
    while (child.firstChild) {
      child = child.firstChild;
    }
    if (child.snapshot.data[AdminLayoutComponent.ROUTE_DATA_PAGENAME]) {
      return child.snapshot.data[AdminLayoutComponent.ROUTE_DATA_PAGENAME];
    }
    return '';
  }

  // setOpenMenuMap(menus: MenuLoginModel[]) {
  //   return menus.some(menu => {
  //     this.openMenuMap[menu.menuId] = false;
  //     if (menu.menuChildren && menu.menuChildren.length > 0) {
  //       this.openMenuMap[menu.menuId] = this.setOpenMenuMap(menu.menuChildren);
  //     }
  //     if (menu.url === this.currentUrl) {
  //       this.openMenuMap[menu.menuId] = true;
  //       return true;
  //     }
  //     return false;
  //   });
  // }

  // openHandler(value: number): void {
  //   for (const key in this.openMenuMap) {
  //     if (key !== value.toString()) {
  //       this.openMenuMap[key] = false;
  //     }
  //   }
  //   this.setParentMenuOpen(value, this.menus);
  // }

  // setParentMenuOpen(value: number, menus: MenuLoginModel[]) {
  //   return menus.some(menu => {
  //     this.openMenuMap[menu.menuId] = false;
  //     if (menu.menuChildren && menu.menuChildren.length > 0) {
  //       this.openMenuMap[menu.menuId] = this.setParentMenuOpen(value, menu.menuChildren);
  //     }
  //     if (menu.menuId === value) {
  //       this.openMenuMap[menu.menuId] = true;
  //       return true;
  //     }
  //     return false;
  //   });
  // }

  getCurrentUrl(router: Router) {
    router.events.subscribe(e => {
      if (e instanceof NavigationEnd) {
        this.currentUrl = e.url;
      }
    });
  }

  logout() {
    // this.store.dispatch(new actionAuth.Logout());
    this.sub = this.authService.logout().subscribe(res => {
      if (res) {
        localStorage.clear();
        this.route.navigate(['/login']);
      }
    }, error => {
      Cookie.delete(Constant.CACHE_KEY.TOKEN);
      localStorage.removeItem(Constant.CACHE_KEY.USER_INFO);
      localStorage.removeItem(Constant.CACHE_KEY.TOKEN);
      this.route.navigate(['/login']);
    });
  }


  onTopbarMobileButtonClick(event) {
    this.mobileTopbarActive = !this.mobileTopbarActive;
    event.preventDefault();
}

onRightMenuButtonClick(event) {
    this.rightMenuActive = !this.rightMenuActive;
    event.preventDefault();
}

onMenuClick($event) {
    this.menuClick = true;

    if (this.inlineMenuActive[this.currentInlineMenuKey] && !this.inlineMenuClick) {
        this.inlineMenuActive[this.currentInlineMenuKey] = false;
    }
}

onSearchKeydown(event) {
    if (event.keyCode === 27) {
        this.search = false;
    }
}

onInlineMenuClick(event, key) {
    if (key !== this.currentInlineMenuKey) {
        this.inlineMenuActive[this.currentInlineMenuKey] = false;
    }

    this.inlineMenuActive[key] = !this.inlineMenuActive[key];
    this.currentInlineMenuKey = key;
    this.inlineMenuClick = true;
}

onTopbarItemClick(event, item) {
    this.topbarItemClick = true;

    if (this.activeTopbarItem === item) {
        this.activeTopbarItem = null;
    }
    else {
        this.activeTopbarItem = item;
    }

    if (item === 'search') {
        this.search = !this.search;
        this.searchClick = !this.searchClick;
    }

    event.preventDefault();
}

onTopbarSubItemClick(event) {
    event.preventDefault();
}

onRTLChange(event) {
    this.app.isRTL = event.checked;
}

onRippleChange(event) {
    this.app.ripple = event.checked;
    this.primengConfig.ripple = event.checked;
}

onConfigClick(event) {
    this.configClick = true;
}

isDesktop() {
    return window.innerWidth > 991;
}

isMobile() {
    return window.innerWidth <= 991;
}

isOverlay() {
    return this.app.menuMode === 'overlay';
}

isStatic() {
    return this.app.menuMode === 'static';
}

isHorizontal() {
    return this.app.menuMode === 'horizontal';
}

isSlim() {
    return this.app.menuMode === 'slim';
}

blockBodyScroll(): void {
    if (document.body.classList) {
        document.body.classList.add('blocked-scroll');
    } else {
        document.body.className += ' blocked-scroll';
    }
}

unblockBodyScroll(): void {
    if (document.body.classList) {
        document.body.classList.remove('blocked-scroll');
    } else {
        document.body.className = document.body.className.replace(new RegExp('(^|\\b)' +
            'blocked-scroll'.split(' ').join('|') + '(\\b|$)', 'gi'), ' ');
    }
}

onMenuButtonClick(event) {
  this.menuActive = !this.menuActive;
  this.topbarMenuActive = false;
  this.topbarRightClick = true;
  this.menuClick = true;

  if (this.isDesktop()) {
      this.staticMenuDesktopInactive = !this.staticMenuDesktopInactive;
  } else {
      this.mobileMenuActive = !this.mobileMenuActive;
      if (this.mobileMenuActive) {
          this.blockBodyScroll();
      } else {
          this.unblockBodyScroll();
      }
  }

  event.preventDefault();
}
}

export function clearState(reducer) {
  return (state, action) => {
    if (action.type === actionAuth.AuthActionTypes.Logout) {
      state = undefined;
    }
    return reducer(state, action);
  };
}
