import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Subject} from 'rxjs';

import {faSearch} from '@fortawesome/free-solid-svg-icons';

import {ManufacturersService} from '../../../../api/services/manufacturers.service';
import {ManufacturerModel} from '../../../../api/models/manufacturer.model';
import {takeUntil} from 'rxjs/operators';
import {ManufacturersListModel} from '../../../../api/models/manufacturers-list.model';
import {FilterViewModel} from '../../../../api/models/filter-view.model';

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.css'],
  providers: [ManufacturersService],
})
export class ProductsFilterComponent implements OnInit, OnDestroy {
  public faSearch = faSearch;
  public form: FormGroup;
  public manufacturers: ManufacturerModel[];
  public viewModel = new FilterViewModel();
  private stop$ = new Subject<void>();

  constructor(private manufacturersService: ManufacturersService) {
  }

  public ngOnInit() {
    this.form = new FormGroup({
      filteredName: new FormControl(''),
    });

    this.manufacturersService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ManufacturersListModel) => this.manufacturers = result.manufacturers, error => console.log(error));
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit() {
    console.log(this.form.getRawValue());
  }
}
