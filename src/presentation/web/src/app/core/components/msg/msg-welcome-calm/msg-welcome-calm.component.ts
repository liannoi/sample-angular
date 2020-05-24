import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-msg-welcome-calm',
  templateUrl: './msg-welcome-calm.component.html',
  styleUrls: ['./msg-welcome-calm.component.css'],
})
export class MsgWelcomeCalmComponent {
  @Input() public text: string;
}
