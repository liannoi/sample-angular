import {PaginationModel} from '../../core/components/pagination/pagination.model';
import {ProductModel} from './product.model';

export interface ProductsListViewModel {
  pagination: PaginationModel;
  products: ProductModel[];
}
