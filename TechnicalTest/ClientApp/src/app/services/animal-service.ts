import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export class AnimalService {

  private baseUrl: string;

  private defaultHeaders: HttpHeaders;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/animals';
    this.defaultHeaders = new HttpHeaders().set("Content-Type", "application/json");
  }

  getAnimals() {
    return this.http.get<IAnimalListItem[]>(this.baseUrl);
  }

  createAnimal(animal: IAnimalListItem) {
    return this.http.post(
      this.baseUrl,
      JSON.stringify(animal),
      { headers: this.defaultHeaders });
  }

  updateAnimal(animal: IAnimalListItem) {
    return this.http.put(
      this.baseUrl,
      JSON.stringify(animal),
      {
        headers: this.defaultHeaders
      });
  }

  deleteAnimal(id: number){
    return this.http.delete(this.baseUrl + "/" + id);
  }
}
