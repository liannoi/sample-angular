import {FilterManufacturerModel} from './filter-manufacturer.model';

export class FilterViewModel {
  constructor(public filteredName = '', public filteredManufacturers: FilterManufacturerModel[] = []) {
  }
}
