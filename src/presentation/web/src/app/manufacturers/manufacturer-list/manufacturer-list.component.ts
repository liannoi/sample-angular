import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faPen, faTimes} from '@fortawesome/free-solid-svg-icons';
import Swal, {SweetAlertResult} from 'sweetalert2';

import {ManufacturersService} from '../shared/manufacturers.service';
import {ManufacturersListViewModel} from '../shared/manufacturers-list-view.model';

@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html',
  styleUrls: ['./manufacturer-list.component.css'],
  providers: [ManufacturersService],
})
export class ManufacturerListComponent implements OnInit, OnDestroy {
  public faPen = faPen;
  public faTimes = faTimes;
  public viewModel: ManufacturersListViewModel;
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private manufacturersService: ManufacturersService, private router: Router) {
    this.titleService.setTitle('Manufacturers - Sample Angular');
  }

  public ngOnInit() {
    this.refreshViewModel();
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onRedirectToUpdate(id = 0) {
    this.router.navigate(['/manufacturers', id]);
  }

  public onRequestDelete(id: number) {
    this.askToDelete().then((result: SweetAlertResult) => {
      if (!result.value) return;

      this.manufacturersService.delete(id)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.processDelete(id), error => console.error(error));
    });
  }

  public onPageChange(page: number) {
    this.refreshViewModel(page);
  }

  private refreshViewModel(page = 1, limit = 10) {
    this.manufacturersService.getAll(page, limit)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  private askToDelete() {
    return Swal.fire({
      title: 'Are you sure you want to permanently delete the record from the repository?',
      text: 'You can’t undo this action.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Delete entry',
    });
  }

  private processDelete(id: number) {
    this.viewModel.manufacturers.forEach((item, index) => {
      if (item.manufacturerId === id) this.viewModel.manufacturers.splice(index, 1);
    });

    this.notifySuccessDelete();
  }

  private notifySuccessDelete() {
    Swal.fire({
      position: 'bottom-end',
      icon: 'success',
      title: 'Manufacturer successfully deleted',
      showConfirmButton: false,
      timer: 1500,
    });
  }
}
