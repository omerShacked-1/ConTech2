import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http"


@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private http: HttpClient) {
   
  }
  tagsUrl = 'api/labels'
  tags: Tag[];
  updateTags(@Inject('BASE_URL') baseUrl: string) {
    this.http.get<Tag[]>(baseUrl + 'api/labels').subscribe(result => {
      this.tags = result;
    }, error => console.error(error));
  }
  getTags() {
    return this.tags;
  }
  
}
interface Tag {
  Id: number,
  Name: string,
  postsLabels: [],
  usersLabels:[]
}
