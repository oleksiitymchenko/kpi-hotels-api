import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-clients-iframe',
  templateUrl: './clients-iframe.component.html',
  styleUrls: ['./clients-iframe.component.css']
})
export class ClientsIframeComponent implements OnInit {
  url: string = "http://kpi-hotels-api.azurewebsites.net/gui/clients";
  urlSafe: SafeResourceUrl;

  constructor(public sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.urlSafe= this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
  }

}
