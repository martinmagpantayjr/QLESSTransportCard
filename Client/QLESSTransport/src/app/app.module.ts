import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TransportCardLoadComponent } from './transport-card/components/transport-card-load/transport-card-load.component';
import { TransportCardPurchaseComponent } from './transport-card/components/transport-card-purchase/transport-card-purchase.component';
import { TransportCardRegisterComponent } from './transport-card/components/transport-card-register/transport-card-register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TransportCardPayComponent } from './transport-card/components/transport-card-pay/transport-card-pay.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TransportCardPurchaseComponent,
    TransportCardLoadComponent,
    TransportCardRegisterComponent,
    TransportCardPayComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
