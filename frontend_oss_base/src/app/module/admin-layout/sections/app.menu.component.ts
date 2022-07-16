import {Component, OnInit} from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { MenuLoginModel } from '../../core/model/auth.model';
import { Constant } from 'src/app/shared/constants/constant.class';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[];
    menus: MenuLoginModel[] = [];

    constructor(public app: AppComponent) {}

    ngOnInit() {
        this.menus = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.MENU));

        // this.model = [
        //     {
        //         items: [
        //             {
        //                 label: 'Submenu 1', icon: 'pi pi-fw pi-align-left',
        //                 items: [
        //                     {
        //                         label: 'Submenu 1.1', icon: 'pi pi-fw pi-align-left',
        //                         items: [
        //                             {label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                             {label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                             {label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                         ]
        //                     },
        //                     {
        //                         label: 'Submenu 1.2', icon: 'pi pi-fw pi-align-left',
        //                         items: [
        //                             {label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']}
        //                         ]
        //                     },
        //                 ]
        //             },
        //             {
        //                 label: 'Submenu 2', icon: 'pi pi-fw pi-align-left',
        //                 items: [
        //                     {
        //                         label: 'Submenu 2.1', icon: 'pi pi-fw pi-align-left',
        //                         items: [
        //                             {label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                             {label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                         ]
        //                     },
        //                     {
        //                         label: 'Submenu 2.2', icon: 'pi pi-fw pi-align-left',
        //                         items: [
        //                             {label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-align-left', routerLink: ['/documentation']},
        //                         ]
        //                     },
        //                 ]
        //             }
        //         ]
        //     }
        // ];
        let menu : MenuItem[] = [];
        let topMenu = new MenuItem();
        topMenu.items = this.createMenu(this.menus);
        menu.push(topMenu);
        this.model = menu;
        // console.log(this.model);
    }

    createMenu(menus: MenuLoginModel[]) : MenuItem [] {
        let items : MenuItem[] = [];
        for(let i = 0 ; i < menus.length; i++) {
            let item : MenuItem = new MenuItem();
            item.label = menus[i].name;
            item.routerLink = [menus[i].url != null ? menus[i].url : '#'];
            item.icon = menus[i].icon;
            if(menus[i].menuChildren != null && menus[i].menuChildren.length > 0) {
                item.items = this.createMenu(menus[i].menuChildren);
            }
            items.push(item);
        }
        return items;
    }

}

export class MenuItem {
    label: String;
    icon: String;
    routerLink: String[];
    items: MenuItem[];
}
