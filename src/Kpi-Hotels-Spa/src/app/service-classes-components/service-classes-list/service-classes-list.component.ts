import { Component, OnInit } from '@angular/core';
import { ServiceClassService } from 'src/app/services/service-classes.service';
import { serviceClass } from 'src/app/models/service-class';

@Component({
  selector: 'app-service-classes-list',
  templateUrl: './service-classes-list.component.html',
  styleUrls: ['./service-classes-list.component.css']
})
export class ServiceClassesListComponent implements OnInit {

  constructor(private service: ServiceClassService) { }
  public serviceClassesList = Array<serviceClass>();
  private subscription;

  ngOnInit(): void {
    console.log("INIT");
    this.subscription = this.service.getAllServiceClasses().subscribe(
      x => {
        this.serviceClassesList = x;
        console.log(x);
      });
  }

  ngOnDestroy():void{
    this.subscription.unsubscribe();
  }

}
