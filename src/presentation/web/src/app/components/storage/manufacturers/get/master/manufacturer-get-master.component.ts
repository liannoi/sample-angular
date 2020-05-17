import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faInfo, faPen, faTimes, IconDefinition} from '@fortawesome/free-solid-svg-icons';

import {ManufacturersListViewModel, ManufacturersService} from '../../../../../../api/sample-angular-api';

@Component({
  selector: 'app-manufacturer-get-master',
  templateUrl: './manufacturer-get-master.component.html',
  styleUrls: ['./manufacturer-get-master.component.css'],
  providers: [ManufacturersService],
})
export class ManufacturerGetMasterComponent implements OnInit, OnDestroy {
  public faPen: IconDefinition = faPen;
  public faInfo: IconDefinition = faInfo;
  public faTimes: IconDefinition = faTimes;
  public viewModel: ManufacturersListViewModel = new ManufacturersListViewModel();
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private manufacturersService: ManufacturersService) {
    this.titleService.setTitle('Manufacturers - Sample Angular');
  }

  ngOnInit(): void {
    this.manufacturersService.getAll(50)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }
}
