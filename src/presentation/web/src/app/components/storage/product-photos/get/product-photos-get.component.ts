import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {faTimes, IconDefinition} from '@fortawesome/free-solid-svg-icons';

import {ProductPhotoModel} from '../../../../../api/models/product-photo.model';
import {ProductPhotosService} from '../../../../../api/services/product-photos.service';

@Component({
  selector: 'app-product-photos-get',
  templateUrl: './product-photos-get.component.html',
  styleUrls: ['./product-photos-get.component.css'],
  providers: [ProductPhotosService],
})
export class ProductPhotosGetComponent implements OnInit, OnDestroy {
  public productPhotos: ProductPhotoModel[] = [];
  public faTimes: IconDefinition = faTimes;
  private stop$ = new Subject<void>();

  constructor(private productPhotosService: ProductPhotosService, private activatedRoute: ActivatedRoute) {
  }

  public ngOnInit(): void {
    this.activatedRoute.params.forEach((params: Params) => {
      this.productPhotosService.getAll(params['id'])
        .pipe(takeUntil(this.stop$))
        .subscribe(result => this.productPhotos = result.productPhotos, error => console.error(error));
    });
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public redirectToAdd(): void {
    /*this.productPhotosService.upload({
      photoId: 104,
      productId: 1,
      path: 'http://dummyimage.com/1795x772.png/ff4444/ffffff',
    })
      .pipe(takeUntil(this.stop$))
      .subscribe(result => console.log(result), error => console.error(error));*/
  }

  public redirectToDelete(id: number): void {
    this.productPhotosService.delete(id)
      .pipe(takeUntil(this.stop$))
      .subscribe(result => console.log(result), error => console.error(error));
  }
}
