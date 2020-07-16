import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { EmployeeService } from "../services/employee-service";

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css'],
  providers: [EmployeeService]
})
export class EmployeesListComponent implements OnInit {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate: TemplateRef<any>;
  @ViewChild('editTemplate', { static: false }) editTemplate: TemplateRef<any>;

  constructor(private readonly employeeService: EmployeeService) {}

  public employeesList: IEmployeeListItem[];

  editedEmployee: IEmployeeListItem;
  isNewRecord: boolean;
  statusMessage: string;

  ngOnInit() {
    this.loadEmployees();
  }

  private loadEmployees() {
    this.employeeService.getEmployees().subscribe(result => {
      this.employeesList = result;
    }, error => console.error(error));
  }

  // add animal
  addEmployee() {
    this.editedEmployee = ({} as IEmployeeListItem);

    this.editedEmployee.name = "";
    this.editedEmployee.lastName = "";

    this.editedEmployee.isMediaInteractivaEmployee = false;
    //this.editedEmployee.animals = IAnimalListItem[];

    this.employeesList .push(this.editedEmployee);
    this.isNewRecord = true;
  }

  // edit animal
  editEmployee(employee: IEmployeeListItem) {
    this.editedEmployee = ({} as IEmployeeListItem);

    this.editedEmployee.id = employee.id;
    this.editedEmployee.name = employee.name;
    this.editedEmployee.lastName = employee.lastName;
    this.editedEmployee.isMediaInteractivaEmployee = employee.isMediaInteractivaEmployee;
    this.editedEmployee.animals = employee.animals;
  }

  // save animal
  saveEmployee() {
    if (this.isNewRecord) {
      // create new animal
      this.employeeService.createEmployee(this.editedEmployee).subscribe(data => {
        this.statusMessage = "Data saved",
          this.loadEmployees();
      });
      this.isNewRecord = false;
      this.editedEmployee = null;
    } else {
      // update animal
      this.employeeService.updateEmployee(this.editedEmployee).subscribe(data => {
        this.statusMessage = "Data updated",
          this.loadEmployees();
      });
      this.editedEmployee = null;
    }
  }

  // cancel edit
  cancelEmployee() {
    // if cancel when adding - remove last record
    if (this.isNewRecord) {
      this.employeesList.pop();
      this.isNewRecord = false;
    }
    this.editedEmployee = null;
  }
  // remove animal
  deleteEmployee(animal: IAnimalListItem) {
    this.employeeService.deleteEmployee(animal.id).subscribe(data => {
      this.statusMessage = "Data was removed",
        this.loadEmployees();
    });
  }

  loadTemplate(animal: IAnimalListItem) {
    if (this.editedEmployee && this.editedEmployee.id === animal.id) {
      return this.editTemplate;
    } else {
      return this.readOnlyTemplate;
    }
  }
}
