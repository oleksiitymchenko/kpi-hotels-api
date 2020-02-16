import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientsListComponent } from './clients-components/clients-list/clients-list.component'
import { ClientsIframeComponent } from './clients-iframe/clients-iframe.component'
import { OrdersListComponent } from './orders-components/orders-list/orders-list.component'
import { ServiceClassesListComponent } from './service-classes-components/service-classes-list/service-classes-list.component'
import { RoomsListComponent } from './rooms-components/rooms-list/rooms-list.component'

const routes: Routes = [
  {
    path: '',
    component: ClientsListComponent
  },
  {
    path: 'clients',
    component: ClientsListComponent
  },
  {
    path: 'orders',
    component: OrdersListComponent
  },
  {
    path: 'rooms',
    component: RoomsListComponent
  },
  {
    path: 'serviceclasses',
    component: ServiceClassesListComponent
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
