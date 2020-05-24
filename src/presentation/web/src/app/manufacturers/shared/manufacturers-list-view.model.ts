import {ManufacturerModel} from './manufacturer.model';
import {PaginationModel} from '../../core/components/pagination/pagination.model';

export interface ManufacturersListViewModel {
  pagination: PaginationModel;
  manufacturers: ManufacturerModel[];
}
