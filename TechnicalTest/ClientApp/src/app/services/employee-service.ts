import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export class EmployeeService {
  private baseUrl: string;

  private defaultHeaders: HttpHeaders;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/employees';
    this.defaultHeaders = new HttpHeaders().set("Content-Type", "application/json");
  }

  getEmployees() {
    return this.http.get<IEmployeeListItem[]>(this.baseUrl);
  }

  createEmployee(employee: IEmployeeListItem) {
    return this.http.post(
      this.baseUrl,
      JSON.stringify(employee),
      { headers: this.defaultHeaders });
  }

  updateEmployee(employee: IEmployeeListItem) {
    
    return this.http.put(
      this.baseUrl,
      JSON.stringify(employee),
      { headers: this.defaultHeaders });
  }

  deleteEmployee(id: number){
    return this.http.delete(this.baseUrl + "/" + id);
  }
}
