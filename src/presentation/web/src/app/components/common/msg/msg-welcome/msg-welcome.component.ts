import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-msg-welcome',
  templateUrl: './msg-welcome.component.html',
  styleUrls: ['./msg-welcome.component.css'],
})
export class MsgWelcomeComponent {
  @Input() public text: string;
}
