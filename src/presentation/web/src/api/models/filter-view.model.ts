import {FilterManufacturerModel} from './filter-manufacturer.model';

export class FilterViewModel {
  constructor(public filteredName: string = '', public filteredManufacturers: FilterManufacturerModel[] = []) {
  }
}
