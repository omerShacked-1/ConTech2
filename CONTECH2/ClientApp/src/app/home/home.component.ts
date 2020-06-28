import { Component } from '@angular/core';
import {  HttpService } from '../http-service.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private service: HttpService) { }
  searchV: string = " ";
  tags = this.service.getTags();
  search() {
    window.alert(this.searchV);
  }
}
