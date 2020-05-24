import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError, delay} from 'rxjs/operators';

import {AbstractApiService} from '../abstract-api.service';
import {productPhotosEndpoint} from '../addresses.consts';
import {ProductPhotoModel, ProductPhotosListViewModel} from '../models/api-productPhotos';

@Injectable()
export class ProductPhotosService extends AbstractApiService<ProductPhotoModel, ProductPhotosListViewModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = productPhotosEndpoint;
  }

  public getAll(id: number = 0, timeout?: number) {
    if (id == 0) return super.getAll(timeout);

    return this.http.get<ProductPhotosListViewModel>(`${this.endpoint}/${id}`)
      .pipe(catchError(this.handleError))
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public upload(id: number, formData: FormData) {
    return this.http.post<ProductPhotoModel>(`${this.endpoint}/${id}`, formData)
      .pipe(catchError(this.handleError));
  }
}
