import {Component} from '@angular/core';
import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-msg-error',
  templateUrl: './msg-error.component.html',
})
export class MsgErrorComponent {
  constructor(private titleService: Title) {
    this.titleService.setTitle('Page Not Found - Hometask');
  }
}
