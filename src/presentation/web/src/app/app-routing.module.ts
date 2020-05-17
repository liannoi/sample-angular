import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/homes/main/home.component';
import {MsgErrorComponent} from './components/helpers/msg/msg-error/msg-error.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '**', component: MsgErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
