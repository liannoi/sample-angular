import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';

import {ProductsService} from '../shared/products.service';
import {ManufacturersService} from '../../manufacturers/shared/manufacturers.service';
import {takeUntil} from 'rxjs/operators';
import {ManufacturerModel} from '../../manufacturers/shared/manufacturer.model';
import {ManufacturersListViewModel} from '../../manufacturers/shared/manufacturers-list-view.model';
import {ProductModel} from '../shared/product.model';
import {NotificationService} from '../../shared/notificationService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  providers: [ProductsService, ManufacturersService, NotificationService],
})
export class ProductComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public model: ProductModel;
  public isInitialized = false;
  public manufacturers: ManufacturerModel[];
  private stop$ = new Subject<void>();

  constructor(private activatedRoute: ActivatedRoute,
              private productsService: ProductsService,
              private manufacturerService: ManufacturersService,
              private router: Router) {
  }

  public ngOnInit() {
    this.initializeForm();
    this.fetchManufacturers();
    this.prepareInputs();
  }

  public ngOnDestroy() {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit() {
    this.model = this.prepareModel();

    if (this.model.productId != 0) {
      this.productsService.update(this.model.productId, this.model)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());

      return;
    }

    this.productsService.create(this.model)
      .pipe(takeUntil(this.stop$))
      .subscribe(() => this.redirectToParent());
  }

  public header(): string {
    return this.model.productId == 0 ? 'Create product' : 'Update product';
  }

  private prepareInputs() {
    this.activatedRoute.params.forEach((params: Params) => {
      let id = params['id'];

      if (id == 0) {
        this.initializeInputs();
        return;
      }

      this.productsService.getById(id)
        .pipe(takeUntil(this.stop$))
        .subscribe((result: ProductModel) => this.initializeInputs(result), error => console.log(error));
    });
  }

  private fetchManufacturers() {
    this.manufacturerService.getAll(1, 200)
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ManufacturersListViewModel) => this.manufacturers = result.manufacturers, error => console.log(error));
  }

  private initializeForm() {
    this.form = new FormGroup({
      name: new FormControl(''),
      productNumber: new FormControl(''),
      manufacturer: new FormGroup({
        manufacturerId: new FormControl(''),
        name: new FormControl(''),
      }),
    });
  }

  private prepareModel() {
    let tmp = this.form.getRawValue();
    tmp.productId = this.model.productId;
    tmp.manufacturer.manufacturerId = parseInt(tmp.manufacturer.manufacturerId);

    return tmp;
  }

  private redirectToParent() {
    return this.router.navigate(['/products']);
  }

  private initializeInputs(model: ProductModel = {
    productId: 0,
    name: '',
    productNumber: '',
    manufacturer: {manufacturerId: 0, name: ''},
  }) {
    this.model = model;
    this.form.patchValue(this.model);
    this.isInitialized = true;
  }
}
