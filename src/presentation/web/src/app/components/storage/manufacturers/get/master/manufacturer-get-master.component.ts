import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faPen, faTimes} from '@fortawesome/free-solid-svg-icons';
import Swal, {SweetAlertResult} from 'sweetalert2';

import {ManufacturersService} from '../../../../../../api/services/manufacturers.service';
import {ManufacturersListModel} from '../../../../../../api/models/manufacturers-list.model';

@Component({
  selector: 'app-manufacturer-get-master',
  templateUrl: './manufacturer-get-master.component.html',
  styleUrls: ['./manufacturer-get-master.component.css'],
  providers: [ManufacturersService],
})
export class ManufacturerGetMasterComponent implements OnInit, OnDestroy {
  public faPen = faPen;
  public faTimes = faTimes;
  public viewModel = new ManufacturersListModel();
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private manufacturersService: ManufacturersService, private router: Router) {
    this.titleService.setTitle('Manufacturers - Sample Angular');
  }

  public ngOnInit() {
    this.manufacturersService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public redirectToUpdate(id = 0) {
    this.router.navigate(['/manufacturer/update', id]);
  }

  public requestDelete(id: number) {
    this.askToDelete().then((result: SweetAlertResult) => {
      if (!result.value) return;

      this.manufacturersService.delete(id)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.processDelete(id), error => console.error(error));
    });
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
