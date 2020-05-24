import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {AbstractApiService} from '../abstract-api.service';
import {productsEndpoint} from '../addresses.consts';
import {ProductModel, ProductsListViewModel} from '../models/api-products';
import {catchError} from 'rxjs/operators';

@Injectable()
export class ProductsService extends AbstractApiService<ProductModel, ProductsListViewModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = productsEndpoint;
  }

  public getAll(page: number = 1, limit: number = 10) {
    return this.http.get<ProductsListViewModel>(`${this.endpoint}?page=${page}&limit=${limit}`)
      .pipe(catchError(this.handleError));
  }
}
