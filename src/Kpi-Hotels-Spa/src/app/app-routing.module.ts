import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientsComponent } from './clients/clients.component'
import { ClientsIframeComponent } from './clients-iframe/clients-iframe.component'
import { OrdersComponent } from './orders/orders.component'
import { ServiceClassesComponent } from './service-classes/service-classes.component'
import { RoomsComponent } from './rooms/rooms.component'

const routes: Routes = [
  {
    path: '',
    component: ClientsComponent
  },
  {
    path: 'clients',
    component: ClientsComponent
  },
  {
    path: 'orders',
    component: OrdersComponent
  },
  {
    path: 'rooms',
    component: RoomsComponent
  },
  {
    path: 'serviceclasses',
    component: ServiceClassesComponent
  },
  {
    path: 'clientsIframe',
    component: ClientsIframeComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
