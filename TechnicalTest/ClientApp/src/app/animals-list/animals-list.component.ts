import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { AnimalService } from "../services/animal-service";
import { EmployeeService } from "../services/employee-service";

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css'],
  providers: [AnimalService, EmployeeService]
})
export class AnimalsListComponent implements OnInit {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
  @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

  types: string[];
  animals: IAnimalListItem[];
  editedAnimal: IAnimalListItem;
  isNewRecord: boolean;
  statusMessage: string;

  employees: IEmployeeListItem[];

  constructor(private readonly animalService: AnimalService,
              private readonly employeesService: EmployeeService) {
    // hardcoded values for this demo-poc
    this.types = ["home", "service"];
  }

  ngOnInit() {
    // todo: those call can be made parallel
    this.loadAnimals();
    this.loadEmployes();
  }

  private loadAnimals() {
    this.animalService.getAnimals().subscribe(result => {
      this.animals = result;
    }, error => console.error(error));
  }

  private loadEmployes() {
    this.employeesService.getEmployees().subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  // add animal
  addAnimal() {
    this.editedAnimal = ({} as IAnimalListItem);

    this.editedAnimal.type = "";
    this.editedAnimal.name = "";
    this.editedAnimal.ownerDisplayName = "";

    this.animals.push(this.editedAnimal);
    this.isNewRecord = true;
  }

  // edit animal
  editAnimal(animal: IAnimalListItem) {
    this.editedAnimal = ({} as IAnimalListItem);

    this.editedAnimal.id = animal.id;
    this.editedAnimal.type = animal.type;
    this.editedAnimal.name = animal.name;
    this.editedAnimal.ownerDisplayName = animal.ownerDisplayName;
  }

  // save animal
  saveAnimal() {
    if (this.isNewRecord) {
      // create new animal
      this.animalService.createAnimal(this.editedAnimal).subscribe(data => {
        this.statusMessage = "Data saved",
          this.loadAnimals();
      });
      this.isNewRecord = false;
      this.editedAnimal = null;
    } else {
      // update animal
      this.animalService.updateAnimal(this.editedAnimal).subscribe(data => {
        this.statusMessage = "Data updated",
          this.loadAnimals();
      });
      this.editedAnimal = null;
    }
  }

  // cancel edit
  cancel() {
    // if cancel when adding - remove last record
    if (this.isNewRecord) {
      this.animals.pop();
      this.isNewRecord = false;
    }
    this.editedAnimal = null;
  }
  // remove animal
  deleteAnimal(animal: IAnimalListItem) {
    this.animalService.deleteAnimal(animal.id).subscribe(data => {
      this.statusMessage = 'Data was removed',
        this.loadAnimals();
    });
  }

  loadTemplate(animal: IAnimalListItem) {
    if (this.editedAnimal && this.editedAnimal.id === animal.id) {
      return this.editTemplate;
    } else {
      return this.readOnlyTemplate;
    }
  }

}
