import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavTopMenuComponent} from './components/common/nav/nav-top-menu/nav-top-menu.component';
import {NavFooterComponent} from './components/common/nav/nav-footer/nav-footer.component';
import {MsgErrorComponent} from './components/common/msg/msg-error/msg-error.component';
import {HomeComponent} from './components/common/homes/main/home.component';
import {MsgDefaultComponent} from './components/common/msg/msg-default/msg-default.component';
import {MsgWelcomeCalmComponent} from './components/common/msg/msg-welcome-calm/msg-welcome-calm.component';
import {MsgWelcomeComponent} from './components/common/msg/msg-welcome/msg-welcome.component';
import {ManufacturerGetMasterComponent} from './components/storage/manufacturers/get/master/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './components/storage/products/get/master/product-get-master.component';
import {ProductUpdateComponent} from './components/storage/products/update/product-update.component';
import {ManufacturerUpdateComponent} from './components/storage/manufacturers/update/manufacturer-update.component';
import {ProductGetFilterComponent} from './components/storage/products/get/filter/product-get-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavTopMenuComponent,
    NavFooterComponent,
    MsgDefaultComponent,
    MsgErrorComponent,
    MsgWelcomeComponent,
    MsgWelcomeCalmComponent,
    ManufacturerGetMasterComponent,
    ProductGetMasterComponent,
    ProductUpdateComponent,
    ManufacturerUpdateComponent,
    ProductGetFilterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
