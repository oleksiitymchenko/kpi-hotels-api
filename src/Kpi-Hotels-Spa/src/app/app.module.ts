import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ClientsListComponent } from './clients-components/clients-list/clients-list.component';
import { OrdersListComponent } from './orders-components/orders-list/orders-list.component';
import { RoomsListComponent } from './rooms-components/rooms-list/rooms-list.component';
import { ServiceClassesListComponent } from './service-classes-components/service-classes-list/service-classes-list.component';
import { ClientsIframeComponent } from './clients-iframe/clients-iframe.component';
import { ClientsCreateComponent } from './clients-components/clients-create/clients-create.component';
import { ClientsDetailsComponent } from './clients-components/clients-details/clients-details.component';
import { ClientsDeleteComponent } from './clients-components/clients-delete/clients-delete.component';
import { ClientsService } from './services/clients.service'
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClientsListComponent,
    OrdersListComponent,
    RoomsListComponent,
    ServiceClassesListComponent,
    ClientsIframeComponent,
    ClientsCreateComponent,
    ClientsDetailsComponent,
    ClientsDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule
  ],
  providers: [
    ClientsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
