import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/services/orders.service';
import { order } from 'src/app/models/order';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {

  constructor(private service: OrdersService) { }
  public orderList = Array<order>();
  private subscription;

  ngOnInit(): void {
    console.log("INIT");
    this.subscription = this.service.getAllOrders().subscribe(
      x => {
        this.orderList = x;
        console.log(x);
      });
  }

  ngOnDestroy():void{
    this.subscription.unsubscribe();
  }

}
