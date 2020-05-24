import {Component, EventEmitter, Input, Output} from '@angular/core';

import {PaginationModel} from '../../../../../api/models/api-products';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
})
export class PaginationComponent {
  @Input() public pagination: PaginationModel;
  @Output() public outputPageChange: EventEmitter<number> = new EventEmitter<number>();

  public onPageChange(page: number) {
    this.outputPageChange.emit(page);
  }
}
