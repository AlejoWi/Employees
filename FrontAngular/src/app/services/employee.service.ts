import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:44398/api/Employees/";

  getEmployees(){
    return this.http.get(this.url + `GetEmployees`)
  }

  GetEmployee(id:string){
    return this.http.get(this.url + "GetEmployee/?id=" + `${id}`)
  }
}
