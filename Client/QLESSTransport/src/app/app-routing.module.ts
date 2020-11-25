import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TransportCardLoadComponent } from './transport-card/components/transport-card-load/transport-card-load.component';
import { TransportCardPayComponent } from './transport-card/components/transport-card-pay/transport-card-pay.component';
import { TransportCardPurchaseComponent } from './transport-card/components/transport-card-purchase/transport-card-purchase.component';
import { TransportCardRegisterComponent } from './transport-card/components/transport-card-register/transport-card-register.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'transport-card-load',
    component: TransportCardLoadComponent
  },
  {
    path: 'transport-card-purchase',
    component: TransportCardPurchaseComponent
  },
  {
    path: 'transport-card-register',
    component: TransportCardRegisterComponent
  },
  {
    path: 'transport-card-pay',
    component: TransportCardPayComponent
  },
  {
    path: '**',
    redirectTo: '/home', pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
