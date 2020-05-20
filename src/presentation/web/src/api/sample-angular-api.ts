import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, delay} from 'rxjs/operators';

import {AbstractApiService} from './abstract-api.service';

//const apiAddress: string = 'http://liannoi01-001-site1.htempurl.com/api';
const apiAddress: string = 'https://localhost:5001/api';

export interface ProductModel {
  productId: number;
  name: string;
  productNumber: string;
  manufacturer: ManufacturerModel;
  photos: PhotoModel[];
}

export class ManufacturerModel {
  constructor(public manufacturerId: number = 0, public name: string = '') {
  }
}

export interface PhotoModel {
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

  public getAll(timeout?: number): Observable<ManufacturersListViewModel> {
    return this.http.get<ManufacturersListViewModel>(manufacturersApiAddress)
      .pipe(catchError(this.handleError))
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public create(model: ManufacturerModel): Observable<ManufacturerModel> {
    return this.http.post<ManufacturerModel>(manufacturersApiAddress, model)
      .pipe(catchError(this.handleError));
  }

  public delete(id: number): Observable<ManufacturerModel> {
    return undefined;
  }

  public getById(id: number): Observable<ManufacturerModel> {
    return this.http.get<ManufacturerModel>(`${manufacturersApiAddress}/${id}`)
      .pipe(catchError(this.handleError));
  }

  public update(id: number, model: ManufacturerModel): Observable<ManufacturerModel> {
    return this.http.put<ManufacturerModel>(manufacturersApiAddress, model)
      .pipe(catchError(this.handleError));
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

  public getAll(timeout?: number): Observable<ProductsListViewModel> {
    return this.http.get<ProductsListViewModel>(productsApiAddress)
      .pipe(catchError(this.handleError))
      .pipe(delay(timeout > 0 ? timeout : 0));
  }

  public getById(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(`${productsApiAddress}/${id}`)
      .pipe(catchError(this.handleError));
  }

  public delete(id: number): Observable<ProductModel> {
    return undefined;
  }

  public update(id: number, model: ProductModel): Observable<ProductModel> {
    return this.http.put<ProductModel>(productsApiAddress, model)
      .pipe(catchError(this.handleError));
  }
}
