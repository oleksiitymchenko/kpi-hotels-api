import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ClientsListComponent } from './clients-components/clients-list/clients-list.component';
import { OrdersComponent } from './orders/orders.component';
import { RoomsComponent } from './rooms/rooms.component';
import { ServiceClassesComponent } from './service-classes/service-classes.component';
import { ClientsIframeComponent } from './clients-iframe/clients-iframe.component';
import { ClientsCreateComponent } from './clients-components/clients-create/clients-create.component';
import { ClientsDetailsComponent } from './clients-components/clients-details/clients-details.component';
import { ClientsDeleteComponent } from './clients-components/clients-delete/clients-delete.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClientsListComponent,
    OrdersComponent,
    RoomsComponent,
    ServiceClassesComponent,
    ClientsIframeComponent,
    ClientsCreateComponent,
    ClientsDetailsComponent,
    ClientsDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
