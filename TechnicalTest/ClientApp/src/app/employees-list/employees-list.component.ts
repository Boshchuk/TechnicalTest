import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  public employeesList: IEmployeeListItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IEmployeeListItem[]>(baseUrl + 'employees-list').subscribe(result => {
      this.employeesList = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface IEmployeeListItem {
  
  name: string;
  lastName: number;
  isMediaInteractivaEmployee: boolean;
}

