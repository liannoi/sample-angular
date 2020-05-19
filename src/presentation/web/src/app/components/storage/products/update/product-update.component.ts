import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

import {
  ManufacturerModel,
  ManufacturersListViewModel,
  ManufacturersService,
  ProductModel,
  ProductsService,
} from '../../../../../api/sample-angular-api';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css'],
  providers: [ProductsService, ManufacturersService],
})
export class ProductUpdateComponent implements OnInit, OnDestroy {
  public productForm: FormGroup;
  public currentProduct: ProductModel;
  public errorMessage: string;
  public manufacturers: ManufacturerModel[];
  private stop$ = new Subject<void>();

  constructor(private activatedRoute: ActivatedRoute, private productsService: ProductsService, private manufacturerService: ManufacturersService, private router: Router, private formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    const self = this;

    this.manufacturerService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ManufacturersListViewModel) => this.setManufacturers(result), error => console.error(error));

    initializeForm.call(this);

    this.activatedRoute.params.forEach((params: Params) => {
      this.productsService.getById(params['id'])
        .pipe(takeUntil(this.stop$))
        .subscribe((result: ProductModel) => this.fillForm(result), error => this.errorMessage = error);
    });

    function initializeForm() {
      self.productForm = self.formBuilder.group({
        productId: [],
        name: [],
        productNumber: [],
        manufacturerId: [],
      });
    }
  }
  
  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit(): void {
    const self = this;
    let model = prepareModel.call(this);

    this.productsService.update(model)
      .pipe(takeUntil(this.stop$))
      .subscribe(() => this.routeToParent(), error => console.error(error));

    function prepareModel() {
      let model = self.productForm.value;
      model.manufacturerId = parseInt(self.productForm.get('manufacturerId').value);
      return model;
    }
  }

  // Helpers.

  private setManufacturers(result: ManufacturersListViewModel) {
    return this.manufacturers = result.manufacturers;
  }

  private fillForm(result: ProductModel): void {
    this.currentProduct = result;
    this.productForm.patchValue(this.currentProduct);
  }

  private routeToParent(): void {
    this.router.navigate(['/products']);
  }
}
