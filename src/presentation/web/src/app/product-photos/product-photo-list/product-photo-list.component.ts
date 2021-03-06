import {Component, OnDestroy} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Title} from '@angular/platform-browser';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faTimes} from '@fortawesome/free-solid-svg-icons';
import Swal from 'sweetalert2';

import {serverAddress} from '../../shared/addresses.consts';
import {ProductPhotosService} from '../shared/product-photos.service';
import {ProductPhotoModel} from '../shared/product-photo.model';
import {ProductPhotosListViewModel} from '../shared/product-photos-list-view.model';

@Component({
  selector: 'app-product-photo-list',
  templateUrl: './product-photo-list.component.html',
  providers: [ProductPhotosService],
})
export class ProductPhotoListComponent implements OnDestroy {
  public viewModel = <ProductPhotosListViewModel>{};
  public faTimes = faTimes;
  public isInitialized = false;
  public readonly serverAddress = serverAddress;
  private stop$ = new Subject<void>();

  constructor(private productPhotosService: ProductPhotosService, private activatedRoute: ActivatedRoute, titleService: Title) {
    titleService.setTitle('Gallery - Sample Angular');
  }

  public ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) =>
      this.productPhotosService.getAll(params['id'])
        .pipe(takeUntil(this.stop$))
        .subscribe((result: ProductPhotosListViewModel) => this.processInitialize(result), error => console.error(error)));
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onRequestDelete(id: number) {
    this.productPhotosService.delete(id)
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ProductPhotoModel) => this.processDelete(result.photoId), error => console.error(error));
  }

  private processInitialize(result: ProductPhotosListViewModel) {
    this.viewModel.productPhotos = result.productPhotos;
    this.isInitialized = true;
  }

  private processDelete(id: number) {
    this.viewModel.productPhotos.forEach((item, index) => {
      if (item.photoId === id) this.viewModel.productPhotos.splice(index, 1);
    });

    this.notifySuccessDelete();
  }

  private notifySuccessDelete() {
    Swal.fire({
      position: 'bottom-end',
      icon: 'success',
      title: 'Photo successfully deleted',
      showConfirmButton: false,
      timer: 1800,
    });
  }
}
