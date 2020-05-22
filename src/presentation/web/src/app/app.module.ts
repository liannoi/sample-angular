import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';

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
import {ProductsFilterComponent} from './components/storage/products-filter/products-filter.component';
import {ProductPhotosGetComponent} from './components/storage/product-photos/get/product-photos-get.component';
import {LoadingAlertComponent} from './components/common/alerts/loading/loading-alert.component';
import {LinkCreateComponent} from './components/common/link-create/link-create.component';
import {FileUploadComponent} from './components/common/file-upload/file-upload.component';

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
    ProductsFilterComponent,
    ProductPhotosGetComponent,
    LoadingAlertComponent,
    LinkCreateComponent,
    FileUploadComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
