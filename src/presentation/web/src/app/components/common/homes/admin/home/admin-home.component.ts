import {Component} from '@angular/core';
import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
})
export class AdminHomeComponent {
  constructor(private titleService: Title) {
    this.titleService.setTitle('Homepage - Admin-side');
  }
}
