import { Component, OnInit, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {

  public animals: IAnimalListItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IAnimalListItem[]>(baseUrl + 'animals-list').subscribe(result => {
      this.animals = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}


interface IAnimalListItem {
  
  name: string;
  ownerDisplayName: number;
  
}
