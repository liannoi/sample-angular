import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError, delay} from 'rxjs/operators';

import {AbstractApiService} from '../abstract-api.service';
import {ProductPhotoModel} from '../models/product-photo.model';
import {ProductPhotosListModel} from '../models/product-photos-list.model';
import {productPhotosEndpoint} from '../addresses.consts';

@Injectable()
export class ProductPhotosService extends AbstractApiService<ProductPhotoModel, ProductPhotosListModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = productPhotosEndpoint;
  }

  public getAll(id = 0, timeout?: number) {
    if (id == 0) return super.getAll(timeout);

    return this.http.get<ProductPhotosListModel>(`${this.endpoint}/${id}`)
      .pipe(catchError(this.handleError))
      .pipe(delay(timeout > 0 ? timeout : 0));
  }
}
