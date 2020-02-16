import { Component, OnInit } from '@angular/core';
import { ClientsService } from 'src/app/services/clients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { client } from 'src/app/models/Client';

@Component({
  selector: 'app-clients-edit',
  templateUrl: './clients-edit.component.html',
  styleUrls: ['./clients-edit.component.css']
})
export class ClientsEditComponent implements OnInit {
  constructor(private apiService: ClientsService, private route: ActivatedRoute, private router: Router) { }
  
  id: any;
  getSub: any;
  client: any;

  createGroup: FormGroup = new FormGroup({
    firstName : new FormControl(),
    lastName: new FormControl,
    phoneNumber: new FormControl,
    address: new FormControl,
    nationality: new FormControl,
    email: new FormControl,
  });
  
  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get("id");
    this.getSub = this.apiService.getClientById(this.id).subscribe(
      data => {
          console.log(data);
          this.client = data;
          this.createGroup.controls.firstName.setValue(data.firstName);
          this.createGroup.controls.lastName.setValue(data.lastName);
          this.createGroup.controls.phoneNumber.setValue(data.phoneNumber);
          this.createGroup.controls.address.setValue(data.address);
          this.createGroup.controls.nationality.setValue(data.nationality);
          this.createGroup.controls.email.setValue(data.email);
        });
  }
  save(): void{
    const clientToUpdate = {
      id: this.id,
      firstName : this.createGroup.controls.firstName.value,
      lastName: this.createGroup.controls.lastName.value,
      phoneNumber: this.createGroup.controls.phoneNumber.value,
      address: this.createGroup.controls.address.value,
      nationality: this.createGroup.controls.nationality.value,
      email: this.createGroup.controls.email.value,
    };
    this.apiService
      .updateClient(Object.assign(new client(), clientToUpdate))
      .subscribe(x => {console.log(x); this.router.navigate(["/clients"])});
  }
}