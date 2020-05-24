import {ManufacturerModel} from './manufacturer.model';

export interface ProductModel {
  productId: number;
  name: string;
  productNumber: string;
  manufacturer: ManufacturerModel;
}
