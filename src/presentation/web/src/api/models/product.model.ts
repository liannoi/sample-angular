import {ManufacturerModel} from './manufacturer.model';

export class ProductModel {
  constructor(public productId: number = 0, public name: string = '', public productNumber: string = '', public manufacturer: ManufacturerModel = new ManufacturerModel()) {
  }
}
