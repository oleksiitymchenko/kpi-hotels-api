import { Component, OnInit } from '@angular/core';
import { client } from 'src/app/models/Client';
import { Router, ActivatedRoute } from '@angular/router';
import { ClientsService } from 'src/app/services/clients.service';

@Component({
  selector: 'app-clients-details',
  templateUrl: './clients-details.component.html',
  styleUrls: ['./clients-details.component.css']
})
export class ClientsDetailsComponent implements OnInit {

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
}
