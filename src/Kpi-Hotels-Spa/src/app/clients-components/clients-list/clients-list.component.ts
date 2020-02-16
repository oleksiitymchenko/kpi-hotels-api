import { Component, OnInit } from '@angular/core';
import { client } from '../../models/Client'
@Component({
  selector: 'app-clients',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit {

  constructor() { }
  public clientsList = Array<client>();
  ngOnInit(): void {
  }

}
