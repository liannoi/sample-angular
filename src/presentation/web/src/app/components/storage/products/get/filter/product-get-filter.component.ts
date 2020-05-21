import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Subject} from 'rxjs';

import {faSearch, IconDefinition} from '@fortawesome/free-solid-svg-icons';

import {ManufacturersService} from '../../../../../../api/services/manufacturers.service';
import {ManufacturerModel} from '../../../../../../api/models/manufacturer.model';
import {takeUntil} from 'rxjs/operators';
import {ManufacturersListModel} from '../../../../../../api/models/manufacturers-list.model';
import {FilterViewModel} from '../../../../../../api/models/filter-view.model';

@Component({
  selector: 'app-product-get-filter',
  templateUrl: './product-get-filter.component.html',
  styleUrls: ['./product-get-filter.component.css'],
  providers: [ManufacturersService],
})
export class ProductGetFilterComponent implements OnInit, OnDestroy {
  public faSearch: IconDefinition = faSearch;
  public form: FormGroup;
  public manufacturers: ManufacturerModel[];
  public viewModel: FilterViewModel = new FilterViewModel();
  private stop$ = new Subject<void>();

  constructor(private manufacturersService: ManufacturersService) {
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      filteredName: new FormControl(''),
    });

    this.manufacturersService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ManufacturersListModel) => this.manufacturers = result.manufacturers, error => console.log(error));
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit(): void {
    console.log(this.form.getRawValue());
  }
}
