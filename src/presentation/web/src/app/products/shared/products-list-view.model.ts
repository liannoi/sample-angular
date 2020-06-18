import {PaginationModel} from '../../common/components/paging/pagination.model';
import {ProductModel} from './product.model';

export interface ProductsListViewModel {
  pagination: PaginationModel;
  products: ProductModel[];
}
