import {ManufacturerModel} from './manufacturer.model';
import {PaginationModel} from './pagination.model';

export interface ManufacturersListViewModel {
  pagination: PaginationModel;
  manufacturers: ManufacturerModel[];
}
