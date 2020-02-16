import { Component, OnInit, OnDestroy } from '@angular/core';
import { client } from '../../models/Client'
import { ClientsService } from 'src/app/services/clients.service';
@Component({
  selector: 'app-clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit, OnDestroy {

  constructor(private service: ClientsService) { }
  public clientsList = Array<client>();
  private subscription;

  ngOnInit(): void {
    this.subscription = this.service.getAllClients().subscribe(
      x => {
        this.clientsList = x;
        console.log(x);
      });
  }
  
  ngOnDestroy():void{
    this.subscription.unsubscribe();
  }

}
