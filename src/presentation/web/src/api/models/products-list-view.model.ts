import {PaginationModel} from './pagination.model';
import {ProductModel} from './product.model';

export interface ProductsListViewModel {
  pagination: PaginationModel;
  products: ProductModel[];
}
