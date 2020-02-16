import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { environment } from '../../environments/environment'
@Component({
  selector: 'app-clients-iframe',
  templateUrl: './clients-iframe.component.html',
  styleUrls: ['./clients-iframe.component.css']
})
export class ClientsIframeComponent implements OnInit {
  url: string = `${environment.hotelsApiUrl}gui/clients`;
  urlSafe: SafeResourceUrl;
  public message: string;
  constructor(public sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.urlSafe= this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
  }
  postMessage(): void{
    const frame = document.getElementById('iframeid') as HTMLIFrameElement; 
    frame.contentWindow.postMessage(this.message, '*');
  }
  onKey(event): void{
    this.message = event.target.value;
  }
}
