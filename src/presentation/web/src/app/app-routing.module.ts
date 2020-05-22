import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/common/homes/main/home.component';
import {MsgErrorComponent} from './components/common/msg/msg-error/msg-error.component';
import {ManufacturerGetMasterComponent} from './components/storage/manufacturers/get/master/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './components/storage/products/get/master/product-get-master.component';
import {ProductUpdateComponent} from './components/storage/products/update/product-update.component';
import {ManufacturerUpdateComponent} from './components/storage/manufacturers/update/manufacturer-update.component';
import {ProductsFilterComponent} from './components/storage/products-filter/products-filter.component';
import {ProductPhotosGetComponent} from './components/storage/product-photos/get/product-photos-get.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerGetMasterComponent},
  {path: 'manufacturer/update/:id', component: ManufacturerUpdateComponent},
  {path: 'products', component: ProductGetMasterComponent},
  {path: 'product/update/:id', component: ProductUpdateComponent},
  {path: 'products/filter', component: ProductsFilterComponent},
  {path: 'product/photos/:id', component: ProductPhotosGetComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
