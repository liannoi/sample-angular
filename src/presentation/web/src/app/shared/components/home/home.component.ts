import {Component} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {NotificationService} from '../../notificationService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [NotificationService],
})
export class HomeComponent {
  constructor(private titleService: Title) {
    this.titleService.setTitle('Hometask');
  }
}
