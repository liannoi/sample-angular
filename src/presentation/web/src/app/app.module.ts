import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavTopMenuComponent} from './components/helpers/nav/nav-top-menu/nav-top-menu.component';
import {NavFooterComponent} from './components/helpers/nav/nav-footer/nav-footer.component';
import {MsgErrorComponent} from './components/helpers/msg/msg-error/msg-error.component';
import {HomeComponent} from './components/homes/main/home.component';
import {MsgDefaultComponent} from './components/helpers/msg/msg-default/msg-default.component';
import {MsgWelcomeCalmComponent} from './components/helpers/msg/msg-welcome-calm/msg-welcome-calm.component';
import {MsgWelcomeComponent} from './components/helpers/msg/msg-welcome/msg-welcome.component';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
