import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientsListComponent } from './clients-components/clients-list/clients-list.component'
import { ClientsIframeComponent } from './clients-iframe/clients-iframe.component'
import { OrdersListComponent } from './orders-components/orders-list/orders-list.component'
import { ServiceClassesListComponent } from './service-classes-components/service-classes-list/service-classes-list.component'
import { RoomsListComponent } from './rooms-components/rooms-list/rooms-list.component'
import { ClientsCreateComponent } from './clients-components/clients-create/clients-create.component'
import { ClientsDeleteComponent } from './clients-components/clients-delete/clients-delete.component'
import { ClientsDetailsComponent } from './clients-components/clients-details/clients-details.component'

const routes: Routes = [
  { path: '',   redirectTo: '/clients', pathMatch: 'full' },
  {
    path: 'clients',
    component: ClientsListComponent,
  },
  {
    path: 'clients/create',
    component: ClientsCreateComponent
  },
  {
    path: 'clients/delete:id',
    component: ClientsDeleteComponent
  },
  {
    path: 'clients/details:id',
    component: ClientsDetailsComponent
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
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
