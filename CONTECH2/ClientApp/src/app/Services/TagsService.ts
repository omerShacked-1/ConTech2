import { Injectable } from "@angular/core";
@Injectable()
export class TagsService {
    getTags() {
        return ['Python', 'Web', 'c#', 'Hizballah', 'The Musim Brothers', 'Geoint', 'Decorator', 'WebStorm'];
    }
}
