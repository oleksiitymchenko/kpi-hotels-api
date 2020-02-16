import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ClientsService } from 'src/app/services/clients.service';
import { Router } from '@angular/router';
import { client } from 'src/app/models/Client';

@Component({
  selector: 'app-clients-create',
  templateUrl: './clients-create.component.html',
  styleUrls: ['./clients-create.component.css']
})
export class ClientsCreateComponent implements OnInit {

  createGroup: FormGroup = new FormGroup({
    firstName : new FormControl(),
    lastName: new FormControl,
    phoneNumber: new FormControl,
    address: new FormControl,
    nationality: new FormControl,
    email: new FormControl,
  });

  constructor(
    private formBuilder: FormBuilder, 
    private router: Router, 
    private apiService: ClientsService) {
    }

  ngOnInit(): void {
  }
  save(){
    const clientToCreate = {
      firstName : this.createGroup.controls.firstName.value,
      lastName: this.createGroup.controls.lastName.value,
      phoneNumber: this.createGroup.controls.phoneNumber.value,
      address: this.createGroup.controls.address.value,
      nationality: this.createGroup.controls.nationality.value,
      email: this.createGroup.controls.email.value,
    };
    this.apiService
      .createClient(Object.assign(new client(), clientToCreate))
      .subscribe(x => {console.log(x); this.router.navigate(["/clients"])});
  }
}
