import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faPen, faTimes, IconDefinition} from '@fortawesome/free-solid-svg-icons';

import {ManufacturersService} from '../../../../../../api/services/manufacturers.service';
import {ManufacturersListModel} from '../../../../../../api/models/manufacturers-list.model';

@Component({
  selector: 'app-manufacturer-get-master',
  templateUrl: './manufacturer-get-master.component.html',
  styleUrls: ['./manufacturer-get-master.component.css'],
  providers: [ManufacturersService],
})
export class ManufacturerGetMasterComponent implements OnInit, OnDestroy {
  public faPen: IconDefinition = faPen;
  public faTimes: IconDefinition = faTimes;
  public viewModel: ManufacturersListModel = new ManufacturersListModel();
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private manufacturersService: ManufacturersService, private router: Router) {
    this.titleService.setTitle('Manufacturers - Sample Angular');
  }

  public ngOnInit(): void {
    this.manufacturersService.getAll(50)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public redirectToUpdate(id: number = 0): void {
    this.router.navigate(['/manufacturer/update', id]);
  }

  public processDelete(id: number): void {
    this.manufacturersService.delete(id)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => {
        console.log(result);
        this.viewModel.manufacturers.forEach((item, index) => {
          if (item.manufacturerId === id) this.viewModel.manufacturers.splice(index, 1);
        });
      }, error => console.error(error));
  }
}
