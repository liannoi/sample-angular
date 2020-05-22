import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {Router} from '@angular/router';

import {faImage, faPen, faTimes} from '@fortawesome/free-solid-svg-icons';
import Swal, {SweetAlertResult} from 'sweetalert2';

import {ProductsService} from '../../../../../../api/services/products.service';
import {ProductsListModel} from '../../../../../../api/models/products-list.model';

@Component({
  selector: 'app-product-get-master',
  templateUrl: './product-get-master.component.html',
  styleUrls: ['./product-get-master.component.css'],
  providers: [ProductsService],
})
export class ProductGetMasterComponent implements OnInit, OnDestroy {
  public faImage = faImage;
  public faPen = faPen;
  public faTimes = faTimes;
  public viewModel = new ProductsListModel();
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private productsService: ProductsService, private router: Router) {
    this.titleService.setTitle('Products - Sample Angular');
  }

  public ngOnInit() {
    this.productsService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public redirectToUpdate(id = 0) {
    this.router.navigate(['/product/update', id]);
  }

  public redirectToPhotos(id: number) {
    this.router.navigate(['/product/photos', id]);
  }

  public requestDelete(id: number) {
    this.askToDelete().then((result: SweetAlertResult) => {
      if (!result.value) return;

      this.productsService.delete(id)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.processDelete(id), error => console.error(error));
    });
  }

  private processDelete(id: number) {
    this.viewModel.products.forEach((item, index) => {
      if (item.productId === id) this.viewModel.products.splice(index, 1);
    });

    this.notifySuccessDelete();
  }

  private notifySuccessDelete() {
    Swal.fire({
      position: 'bottom-end',
      icon: 'success',
      title: 'Product successfully deleted',
      showConfirmButton: false,
      timer: 1500,
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
}
