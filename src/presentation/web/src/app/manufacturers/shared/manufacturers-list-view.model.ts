import {ManufacturerModel} from './manufacturer.model';
import {PaginationModel} from '../../common/components/paging/pagination.model';

export interface ManufacturersListViewModel {
  pagination: PaginationModel;
  manufacturers: ManufacturerModel[];
}
