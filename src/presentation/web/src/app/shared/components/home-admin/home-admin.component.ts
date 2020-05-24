import {Component} from '@angular/core';
import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-home-admin',
  templateUrl: './home-admin.component.html',
})
export class HomeAdminComponent {
  constructor(private titleService: Title) {
    this.titleService.setTitle('Homepage - Admin-side');
  }
}
