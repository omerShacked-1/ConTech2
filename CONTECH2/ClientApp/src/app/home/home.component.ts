import { Component } from '@angular/core';
import { TagsService } from "../Services/TagsService";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private tagsService: TagsService) { }
  tags = this.tagsService.getTags()
  menList = [{ name: "omer" }, {name:"itay"}]
  searchV: string = "";
  search() {
    window.alert(this.searchV);
  }
}
