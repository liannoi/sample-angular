import {Component, OnDestroy, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {Subject} from 'rxjs';

import {faInfo, faPen, faTimes, IconDefinition} from '@fortawesome/free-solid-svg-icons';

import {ProductModel, ProductsListViewModel, ProductsService} from '../../../../../../api/sample-angular-api';
import {takeUntil} from 'rxjs/operators';
import {Router} from '@angular/router';

@Component({
  selector: 'app-product-get-master',
  templateUrl: './product-get-master.component.html',
  styleUrls: ['./product-get-master.component.css'],
  providers: [ProductsService],
})
export class ProductGetMasterComponent implements OnInit, OnDestroy {
  public faPen: IconDefinition = faPen;
  public faInfo: IconDefinition = faInfo;
  public faTimes: IconDefinition = faTimes;
  public viewModel: ProductsListViewModel = new ProductsListViewModel();
  private stop$ = new Subject<void>();

  constructor(private titleService: Title, private productsService: ProductsService, private router: Router) {
    this.titleService.setTitle('Products - Sample Angular');
  }

  public ngOnInit(): void {
    this.productsService.getAll()
      .pipe(takeUntil(this.stop$))
      .subscribe(result => this.viewModel = result, error => console.error(error));
  }

  public ngOnDestroy(): void {
    this.stop$.next();
    this.stop$.complete();
  }

  public onProductUpdateClick(product: ProductModel): void {
    this.router.navigate(['/products/update', product.productId]);
  }
}
