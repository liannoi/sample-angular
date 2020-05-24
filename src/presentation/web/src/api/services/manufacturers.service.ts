import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {AbstractApiService} from '../abstract-api.service';
import {manufacturersEndpoint} from '../addresses.consts';
import {ManufacturerModel, ManufacturersListViewModel} from '../models/api-manufacturers';

@Injectable()
export class ManufacturersService extends AbstractApiService<ManufacturerModel, ManufacturersListViewModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = manufacturersEndpoint;
  }
}
