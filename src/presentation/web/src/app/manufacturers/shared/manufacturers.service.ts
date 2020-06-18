import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError} from 'rxjs/operators';

import {AbstractApiService} from '../../common/services/abstract-api.service';
import {manufacturersEndpoint} from '../../shared/addresses.consts';
import {ManufacturerModel} from './manufacturer.model';
import {ManufacturersListViewModel} from './manufacturers-list-view.model';

@Injectable()
export class ManufacturersService extends AbstractApiService<ManufacturerModel, ManufacturersListViewModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = manufacturersEndpoint;
  }

  public getAll(page = 1, limit = 10) {
    return this.http.get<ManufacturersListViewModel>(`${this.endpoint}?page=${page}&limit=${limit}`)
      .pipe(catchError(this.handleError));
  }
}
