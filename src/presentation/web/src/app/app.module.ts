import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavTopMenuComponent} from './core/components/nav/nav-top-menu/nav-top-menu.component';
import {NavFooterComponent} from './core/components/nav/nav-footer/nav-footer.component';
import {MsgErrorComponent} from './core/components/msg/msg-error/msg-error.component';
import {HomeComponent} from './shared/components/home/home.component';
import {MsgDefaultComponent} from './core/components/msg/msg-default/msg-default.component';
import {MsgWelcomeCalmComponent} from './core/components/msg/msg-welcome-calm/msg-welcome-calm.component';
import {MsgWelcomeComponent} from './core/components/msg/msg-welcome/msg-welcome.component';
import {ManufacturerGetMasterComponent} from './manufacturers/manufacturer-list/manufacturer-get-master.component';
import {ProductGetMasterComponent} from './products/product-list/product-get-master.component';
import {ProductUpdateComponent} from './products/product/product-update.component';
import {ManufacturerUpdateComponent} from './manufacturers/manufacturer/manufacturer-update.component';
import {ProductPhotosGetComponent} from './product-photos/product-photo-list/product-photos-get.component';
import {LoadingAlertComponent} from './core/components/alerts/alert-loading/loading-alert.component';
import {LinkCreateComponent} from './core/components/link-create/link-create.component';
import {FileUploadComponent} from './core/components/file-upload/file-upload.component';
import {PaginationComponent} from './core/components/pagination/pagination.component';

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
    ProductPhotosGetComponent,
    LoadingAlertComponent,
    LinkCreateComponent,
    FileUploadComponent,
    PaginationComponent,
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
