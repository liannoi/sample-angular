import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {AbstractApiService} from '../abstract-api.service';
import {ProductModel} from '../models/product.model';
import {ProductsListModel} from '../models/products-list.model';
import {productsEndpoint} from '../addresses.consts';

@Injectable()
export class ProductsService extends AbstractApiService<ProductModel, ProductsListModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = productsEndpoint;
  }
}
