import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/common/homes/main/home.component';
import {MsgErrorComponent} from './components/common/msg/msg-error/msg-error.component';
import {ManufacturerGetMasterComponent} from './components/storage/manufacturers/get/master/manufacturer-get-master.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'manufacturers', component: ManufacturerGetMasterComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
