import {ManufacturerModel} from './manufacturer.model';

export class ProductModel {
  constructor(public productId = 0, public name = '', public productNumber = '', public manufacturer = new ManufacturerModel()) {
  }
}
