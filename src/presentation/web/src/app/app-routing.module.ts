import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/common/homes/main/home.component';
import {MsgErrorComponent} from './components/common/msg/msg-error/msg-error.component';
import {ManufacturerGetMasterComponent} from './components/storage/manufacturers/get/master/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './components/storage/products/get/master/product-get-master.component';
import {ProductUpdateComponent} from './components/storage/products/update/product-update.component';
import {ManufacturerUpdateComponent} from './components/storage/manufacturers/update/manufacturer-update.component';
import {ProductPhotosGetComponent} from './components/storage/product-photos/get/product-photos-get.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerGetMasterComponent},
  {path: 'manufacturers/update/:id', component: ManufacturerUpdateComponent},
  {path: 'products', component: ProductGetMasterComponent},
  {path: 'products/update/:id', component: ProductUpdateComponent},
  {path: 'products/photos/:id', component: ProductPhotosGetComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
