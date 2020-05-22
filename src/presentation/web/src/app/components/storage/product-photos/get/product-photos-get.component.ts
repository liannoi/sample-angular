import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faTimes} from '@fortawesome/free-solid-svg-icons';

import {ProductPhotoModel} from '../../../../../api/models/product-photo.model';
import {ProductPhotosService} from '../../../../../api/services/product-photos.service';
import {ProductPhotosListModel} from '../../../../../api/models/product-photos-list.model';

@Component({
  selector: 'app-product-photos-get',
  templateUrl: './product-photos-get.component.html',
  providers: [ProductPhotosService],
})
export class ProductPhotosGetComponent implements OnInit, OnDestroy {
  public productPhotos: ProductPhotoModel[] = [];
  public faTimes = faTimes;
  public isInitialized = false;
  private stop$ = new Subject<void>();

  constructor(private productPhotosService: ProductPhotosService, private activatedRoute: ActivatedRoute) {
  }

  public ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) =>
      this.productPhotosService.getAll(params['id'])
        .pipe(takeUntil(this.stop$))
        .subscribe((result: ProductPhotosListModel) => this.processInitialize(result), error => console.error(error)));
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public redirectToUpload() {
    this.productPhotosService.create(new ProductPhotoModel(104, this.productPhotos[0].productId, 'http://dummyimage.com/1795x772.png/ff4444/ffffff'))
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ProductPhotoModel) => this.processUpload(result), error => console.error(error));
  }

  public requestDelete(id: number) {
    this.productPhotosService.delete(id)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.processDelete(result), error => console.error(error));
  }

  private processUpload(result: ProductPhotoModel) {
    console.log(result);
  }

  private processInitialize(result: ProductPhotosListModel) {
    this.productPhotos = result.productPhotos;
    this.isInitialized = true;
  }

  private processDelete(result: ProductPhotoModel) {
    console.log(result);
  }
}
