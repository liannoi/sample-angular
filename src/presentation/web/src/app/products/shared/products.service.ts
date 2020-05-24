import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError} from 'rxjs/operators';

import {AbstractApiService} from '../../core/services/api/abstract-api.service';
import {productsEndpoint} from '../../shared/addresses.consts';
import {ProductsListViewModel} from './products-list-view.model';
import {ProductModel} from './product.model';

@Injectable()
export class ProductsService extends AbstractApiService<ProductModel, ProductsListViewModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = productsEndpoint;
  }

  public getAll(page = 1, limit = 10) {
    return this.http.get<ProductsListViewModel>(`${this.endpoint}?page=${page}&limit=${limit}`)
      .pipe(catchError(this.handleError));
  }
}
