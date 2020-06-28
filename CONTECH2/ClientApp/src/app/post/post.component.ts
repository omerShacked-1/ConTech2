import { Component, OnInit } from '@angular/core';
import { TagsService } from "../Services/TagsService";

@Component({
  selector: 'app-post',
  templateUrl: './post.template.html',
})
export class PostComponent implements OnInit {
  constructor(private tagsService: TagsService) { }
  tags = this.tagsService.getTags();
  ngOnInit() {
  }
}
