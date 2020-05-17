import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {delay} from 'rxjs/operators';

import {AbstractApiService} from './abstract-api.service';

export interface ManufacturerModel {
  manufacturerId: number;
  name: string;
}

export class ManufacturersListViewModel {
  public manufacturers: ManufacturerModel[];
}

const apiAddress: string = 'https://localhost:5001/api';
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
