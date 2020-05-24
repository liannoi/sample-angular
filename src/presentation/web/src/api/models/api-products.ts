import {ManufacturerModel} from './api-manufacturers';

export interface ProductsListViewModel {
  pagination: PaginationModel;
  products: ProductModel[];
}

export interface PaginationModel {
  totalItems: number;
  itemsPerPage: number;
  currentPage: number;
  totalPages: number;
}

export interface ProductModel {
  productId: number;
  name: string;
  productNumber: string;
  manufacturer: ManufacturerModel;
}
