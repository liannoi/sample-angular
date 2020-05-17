import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {delay} from 'rxjs/operators';

import {AbstractApiService} from './abstract-api.service';

const apiAddress: string = 'https://localhost:5001/api';

export interface ManufacturerModel {
  manufacturerId: number;
  name: string;
}

export class ManufacturersListViewModel {
  public manufacturers: ManufacturerModel[];

  constructor(manufacturers: ManufacturerModel[] = []) {
    this.manufacturers = manufacturers;
  }
}


const manufacturersApiAddress: string = `${apiAddress}/manufacturers`;

@Injectable()
export class ManufacturersService extends AbstractApiService<ManufacturerModel, ManufacturersListViewModel> {
  constructor(http: HttpClient) {
    super(http);
  }

  public getAll(limit: number = 0, timeout?: number): Observable<ManufacturersListViewModel> {
    return this.http.get<ManufacturersListViewModel>(`${manufacturersApiAddress}/getall/${limit}`)
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public create(model: ManufacturerModel): Observable<ManufacturerModel> {
    return undefined;
  }

  public delete(model: ManufacturerModel): Observable<ManufacturerModel> {
    return undefined;
  }

  public getById(id: number): Observable<ManufacturerModel> {
    return undefined;
  }

  public update(model: ManufacturerModel): Observable<ManufacturerModel> {
    return undefined;
  }
}

export interface ProductModel {
  productId: number;
  manufacturerId: number;
  name: string;
  productNumber: string;
  photos: ProductPhotoModel[];
}

export interface ProductPhotoModel {
  photoId: number;
  productId: number;
  path: string;
}

export class ProductsListViewModel {
  public products: ProductModel[];

  constructor(products: ProductModel[] = []) {
    this.products = products;
  }
}

const productsApiAddress: string = `${apiAddress}/products`;

@Injectable()
export class ProductsService extends AbstractApiService<ProductModel, ProductsListViewModel> {
  constructor(http: HttpClient) {
    super(http);
  }

  public create(model: ProductModel): Observable<ProductModel> {
    return undefined;
  }

  public delete(model: ProductModel): Observable<ProductModel> {
    return undefined;
  }

  public getAll(limit: number = 0, timeout?: number): Observable<ProductsListViewModel> {
    return this.http.get<ProductsListViewModel>(`${productsApiAddress}/getall/${limit}`)
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public getById(id: number): Observable<ProductModel> {
    return undefined;
  }

  public update(model: ProductModel): Observable<ProductModel> {
    return undefined;
  }
}
