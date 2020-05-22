import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-link-create',
  templateUrl: './link-create.component.html',
  styleUrls: ['./link-create.component.css'],
})
export class LinkCreateComponent {
  @Input() public title: string;
}
