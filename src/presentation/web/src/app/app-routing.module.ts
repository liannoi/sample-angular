import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/common/homes/main/home.component';
import {MsgErrorComponent} from './components/common/msg/msg-error/msg-error.component';
import {ManufacturerGetMasterComponent} from './components/storage/manufacturers/get/master/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './components/storage/products/get/master/product-get-master.component';
import {ProductUpdateComponent} from './components/storage/products/update/product-update.component';
import {ManufacturerUpdateComponent} from './components/storage/manufacturers/update/manufacturer-update.component';
import {ProductGetFilterComponent} from './components/storage/products-filter/product-get-filter.component';
import {ProductGetPhotoComponent} from './components/storage/product-photos/get/product-get-photo.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerGetMasterComponent},
  {path: 'manufacturer/update/:id', component: ManufacturerUpdateComponent},
  {path: 'products', component: ProductGetMasterComponent},
  {path: 'product/update/:id', component: ProductUpdateComponent},
  {path: 'products/products-filter', component: ProductGetFilterComponent},
  {path: 'product/photos/:id', component: ProductGetPhotoComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
