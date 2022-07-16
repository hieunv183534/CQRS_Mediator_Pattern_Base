import {Component} from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { AdminLayoutComponent } from '../admin-layout.component';

@Component({
    selector: 'app-rightmenu',
    templateUrl: './app.rightmenu.component.html'
})
export class AppRightMenuComponent {
    constructor(public appMain: AdminLayoutComponent, public app: AppComponent) {}
}
