import {ProductModel} from './product.model';

export class ProductsListModel {
  constructor(public products: ProductModel[] = []) {
  }
}
