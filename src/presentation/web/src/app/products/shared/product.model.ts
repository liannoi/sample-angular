import {ManufacturerModel} from '../../manufacturers/shared/manufacturer.model';

export interface ProductModel {
  productId: number;
  name: string;
  productNumber: string;
  manufacturer: ManufacturerModel;
}
