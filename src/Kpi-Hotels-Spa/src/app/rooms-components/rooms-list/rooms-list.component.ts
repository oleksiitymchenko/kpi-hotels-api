import { Component, OnInit } from '@angular/core';
import { RoomsService } from 'src/app/services/rooms.service';
import { room } from 'src/app/models/room';

@Component({
  selector: 'app-rooms-list',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.css']
})
export class RoomsListComponent implements OnInit {

  constructor(private service: RoomsService) { }
  public roomList = Array<room>();
  private subscription;

  ngOnInit(): void {
    console.log("INIT");
    this.subscription = this.service.getAllRooms().subscribe(
      x => {
        this.roomList = x;
        console.log(x);
      });
  }

  ngOnDestroy():void{
    this.subscription.unsubscribe();
  }
}
