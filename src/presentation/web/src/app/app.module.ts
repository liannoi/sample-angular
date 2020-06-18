import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavTopMenuComponent} from './common/components/nav/nav-top-menu/nav-top-menu.component';
import {NavFooterComponent} from './common/components/nav/nav-footer/nav-footer.component';
import {MsgErrorComponent} from './common/components/msg/msg-error/msg-error.component';
import {HomeComponent} from './shared/components/home/home.component';
import {MsgDefaultComponent} from './common/components/msg/msg-default/msg-default.component';
import {MsgWelcomeCalmComponent} from './common/components/msg/msg-welcome-calm/msg-welcome-calm.component';
import {MsgWelcomeComponent} from './common/components/msg/msg-welcome/msg-welcome.component';
import {ManufacturerListComponent} from './manufacturers/manufacturer-list/manufacturer-list.component';
import {ProductListComponent} from './products/product-list/product-list.component';
import {ProductComponent} from './products/product/product.component';
import {ManufacturerComponent} from './manufacturers/manufacturer/manufacturer.component';
import {ProductPhotoListComponent} from './product-photos/product-photo-list/product-photo-list.component';
import {AlertLoadingComponent} from './common/components/alert-loading/alert-loading.component';
import {LinkCreateComponent} from './common/components/link-create/link-create.component';
import {FileUploadComponent} from './common/components/file-upload/file-upload.component';
import {PaginationComponent} from './common/components/paging/pagination.component';

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
    ManufacturerListComponent,
    ProductListComponent,
    ProductComponent,
    ManufacturerComponent,
    ProductPhotoListComponent,
    AlertLoadingComponent,
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
