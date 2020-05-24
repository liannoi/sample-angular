import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './shared/components/home/home.component';
import {MsgErrorComponent} from './core/components/msg/msg-error/msg-error.component';
import {ManufacturerGetMasterComponent} from './manufacturers/manufacturer-list/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './products/product-list/product-get-master.component';
import {ProductUpdateComponent} from './products/product/product-update.component';
import {ManufacturerUpdateComponent} from './manufacturers/manufacturer/manufacturer-update.component';
import {ProductPhotosGetComponent} from './product-photos/product-photo-list/product-photos-get.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerGetMasterComponent},
  {path: 'manufacturers/manufacturer/:id', component: ManufacturerUpdateComponent},
  {path: 'products', component: ProductGetMasterComponent},
  {path: 'products/manufacturer/:id', component: ProductUpdateComponent},
  {path: 'products/photos/:id', component: ProductPhotosGetComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
