import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {ManufacturersListModel} from '../models/manufacturers-list.model';
import {ManufacturerModel} from '../models/manufacturer.model';
import {AbstractApiService} from '../abstract-api.service';
import {manufacturersEndpoint} from '../addresses.consts';

@Injectable()
export class ManufacturersService extends AbstractApiService<ManufacturerModel, ManufacturersListModel> {
  constructor(http: HttpClient) {
    super(http);
    this.endpoint = manufacturersEndpoint;
  }
}
