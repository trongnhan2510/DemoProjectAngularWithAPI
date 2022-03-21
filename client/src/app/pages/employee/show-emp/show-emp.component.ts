import { Component, OnInit, OnDestroy } from '@angular/core';
import { Employee } from 'src/app/Models/Employee';
import { DatePipe } from '@angular/common';
import { Order } from 'src/app/Models/Order';
import { RestAPIService } from 'src/app/services/rest-api.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { User } from 'src/app/Models/User';
import { EmployeeService } from 'src/app/services/employee.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {
  employees: Employee[] = [];
  orders: Order[] = [];
  ModelTitle!: string;
  ActivateAddEditEmpComp: Boolean = false;
  employee: any;
  constructor(private employeeService: EmployeeService,private orderService: OrderService, private datePipe: DatePipe) { }
  ngOnInit(): void {
    this.getEmpAll();
    this.getAllOrder();
  }
  getEmpAll() {
    this.employeeService.get().subscribe((data: any) => {
      this.employees = data as Employee[];
    });
  }
  getAllOrder() {
    this.orderService.get().subscribe((data: any) => {
      this.orders = data as Order[];
    });
  }
  addClick() {
    this.employee = {
      employee_ID: 0,
      employee_Name: "",
      address: "",
      gender: true,
      telephone: "",
      dateOfBirth: this.datePipe.transform(new Date(), 'yyyy-MM-dd')
    }
    this.ModelTitle = "Add Employee";
    this.ActivateAddEditEmpComp = true;
  }
  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.getEmpAll();
  }
  editClick(item: any) {
    this.employee = item;
    this.ModelTitle = "Edit Employee";
    this.ActivateAddEditEmpComp = true;
  }
  deleteClick(id: any) {
    if (confirm('Are you sure??') == true) {
      for (let index = 0; index < this.orders.length; index++) {
        if (this.orders[index].employee_ID == id) {
          alert("Có khóa ngoại");
          return;
        }
      }
      this.employeeService.delete(id).subscribe((data: any) => {
        alert("Success");
        this.getEmpAll();
      });
    }
  }
}
