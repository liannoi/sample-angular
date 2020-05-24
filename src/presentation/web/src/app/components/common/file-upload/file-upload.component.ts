import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {takeUntil} from 'rxjs/operators';
import {Subject} from 'rxjs';

import {ProductPhotoModel} from '../../../../api/models/product-photo.model';
import {ProductPhotosService} from '../../../../api/services/product-photos.service';
import {ProductPhotosListModel} from '../../../../api/models/product-photos-list.model';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
  providers: [ProductPhotosService],
})
export class FileUploadComponent implements OnInit, OnDestroy {
  public formData: FormData;
  public viewModel = new ProductPhotosListModel();
  private stop$ = new Subject<void>();

  constructor(private productPhotosService: ProductPhotosService, private activatedRoute: ActivatedRoute) {
  }

  private _productId: string;

  public get productId(): number {
    return parseInt(this._productId);
  }

  public ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      this._productId = params['id'];
      this.initializeProductPhotos();
    });
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onFileChanged = (files) => {
    if (files.length === 0) return;

    this.prepareFormData(files);
  };

  public onRequestUpload() {
    this.productPhotosService.upload(this.productId, this.formData)
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ProductPhotoModel) => window.location.reload(), error => console.error(error));
  }

  public uploadMessage() {
    return !this.formData ? 'Choose file...' : 'Ready to upload';
  }

  private initializeProductPhotos() {
    this.productPhotosService.getAll(this.productId)
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ProductPhotosListModel) => this.viewModel.productPhotos = result.productPhotos, error => console.error(error));
  }

  private prepareFormData(files) {
    let fileToUpload = <File>files[0];
    this.formData = new FormData();
    this.formData.append('file', fileToUpload, fileToUpload.name);
  }
}
