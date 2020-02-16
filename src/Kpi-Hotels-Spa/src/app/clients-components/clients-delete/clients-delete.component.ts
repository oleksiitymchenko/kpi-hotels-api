import { Component, OnInit, OnDestroy } from '@angular/core';
import { client } from '../../models/client'
import { Router, ActivatedRoute } from '@angular/router';
import { ClientsService } from 'src/app/services/clients.service';

@Component({
  selector: 'app-clients-delete',
  templateUrl: './clients-delete.component.html',
  styleUrls: ['./clients-delete.component.css']
})
export class ClientsDeleteComponent implements OnInit, OnDestroy {

  constructor(
    private router: Router, 
    private apiService: ClientsService,
    private route:ActivatedRoute) { }
  
  private id: string;
  public client: client = new client();
  private getSub;
  private delSub;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get("id");
    this.getSub = this.apiService.getClientById(this.id).subscribe(
      data => {
        console.log(data);
        this.client = data;
      }
    )
  }
  ngOnDestroy(): void{
    this.getSub.unsubscribe();
    if(this.delSub){
      this.delSub.unsubscribe();
    }
  }
  deleteEntity(): void{
    this.delSub = this.apiService.deleteClientById(this.id).subscribe(
      x => {
        console.log(x);
        this.router.navigate(["/clients"]);
      }
    )
  }
}
