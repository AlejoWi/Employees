import { Component } from '@angular/core';
import { Employee } from './models/Employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  employee:Employee = new Employee();
  datatable:any = [];

  constructor(private employeeService:EmployeeService){

  }
  ngOnInit(): void{
    this.onDataTable();
  }

  OnSearchEmployee(employee:Employee){
    if (employee.id === "") {
      this.employeeService.getEmployees().subscribe(res => {
        this.datatable = res;      
      });
    }
    else{
      this.employeeService.GetEmployee(employee.id).subscribe(res =>{
      this.datatable = res;
      });
    }     
  }

  onDataTable(){
    this.employeeService.getEmployees().subscribe(res => {
      this.datatable = res;      
    });
  }

}
