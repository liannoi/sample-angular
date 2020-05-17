import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-msg-default',
  templateUrl: './msg-default.component.html',
  styleUrls: ['./msg-default.component.css'],
})
export class MsgDefaultComponent {
  @Input() public text: string;
}
