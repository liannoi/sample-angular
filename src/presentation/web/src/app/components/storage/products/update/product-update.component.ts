import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subject} from 'rxjs';

import {ProductsService} from '../../../../../api/services/products.service';
import {ManufacturersService} from '../../../../../api/services/manufacturers.service';
import {ProductModel} from '../../../../../api/models/product.model';
import {ManufacturerModel} from '../../../../../api/models/manufacturer.model';
import {takeUntil} from 'rxjs/operators';
import {ManufacturersListModel} from '../../../../../api/models/manufacturers-list.model';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  providers: [ProductsService, ManufacturersService],
})
export class ProductUpdateComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public model: ProductModel;
  public manufacturers: ManufacturerModel[];
  private stop$ = new Subject<void>();

  constructor(private activatedRoute: ActivatedRoute, private productsService: ProductsService, private manufacturerService: ManufacturersService, private router: Router) {
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(''),
      productNumber: new FormControl(''),
      manufacturer: new FormGroup({
        manufacturerId: new FormControl(''),
        name: new FormControl(''),
      }),
    });

    this.manufacturerService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe((result: ManufacturersListModel) => this.manufacturers = result.manufacturers, error => console.log(error));

    this.activatedRoute.params.forEach((params: Params) => {
      let id = params['id'];

      if (id != 0) {
        this.productsService.getById(id)
          .pipe(takeUntil(this.stop$))
          .subscribe((result: ProductModel) => this.initializeInputs(result), error => console.log(error));
      } else {
        this.initializeInputs();
      }
    });
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public onSubmit() {
    let id: number = this.model.productId;
    this.model = this.form.getRawValue();
    this.model.productId = id;

    if (id != 0) {
      this.productsService.update(id, this.model)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());
    } else {
      this.productsService.create(this.model)
        .pipe(takeUntil(this.stop$))
        .subscribe(() => this.redirectToParent());
    }
  }

  private redirectToParent(): Promise<boolean> {
    return this.router.navigate(['/products']);
  }

  private initializeInputs(model: ProductModel = new ProductModel()): void {
    this.model = model;
    this.form.patchValue(this.model);
  }
}
