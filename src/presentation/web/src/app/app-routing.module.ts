import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './shared/components/home/home.component';
import {MsgErrorComponent} from './common/components/msg/msg-error/msg-error.component';
import {ManufacturerListComponent} from './manufacturers/manufacturer-list/manufacturer-list.component';
import {ProductListComponent} from './products/product-list/product-list.component';
import {ProductComponent} from './products/product/product.component';
import {ManufacturerComponent} from './manufacturers/manufacturer/manufacturer.component';
import {ProductPhotoListComponent} from './product-photos/product-photo-list/product-photo-list.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerListComponent},
  {path: 'manufacturers/:id', component: ManufacturerComponent},
  {path: 'products', component: ProductListComponent},
  {path: 'products/:id', component: ProductComponent},
  {path: 'products/photos/:id', component: ProductPhotoListComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
