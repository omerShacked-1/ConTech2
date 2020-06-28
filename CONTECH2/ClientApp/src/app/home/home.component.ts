import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  menList = [{ name: "omer" }, {name:"itay"}]
  searchV: string = "";
  search() {
    window.alert(this.searchV);
  }
}
