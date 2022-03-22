import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/Models/Order';
import { DatePipe } from '@angular/common';
import { Customer } from 'src/app/Models/Customer';
import { Employee } from 'src/app/Models/Employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { CustomerService } from 'src/app/services/customer.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-show-order',
  templateUrl: './show-order.component.html',
  styleUrls: ['./show-order.component.css']
})
export class ShowOrderComponent implements OnInit {
  listOrders:Order[] = [];
  ModelTitle!:string;
  ActivateAddEditEmpComp:Boolean = false;
  order!:any;
  test:any;
  constructor(private orderService: OrderService,private datePipe: DatePipe, private empService: EmployeeService, private cusService: CustomerService) { }
  ngOnInit(): void {
    this.getOrderAll();
  }
  getOrderAll()
  {
    this.orderService.get().subscribe((data:any)=>{
        this.listOrders = data;
    });
  }
  addClick()
  {
    this.order ={
      order_ID:0,
      saleofDate: this.datePipe.transform(new Date(), 'yyyy-MM-dd'),
      total:1,
      customer_ID: this.listOrders[0].customer.customer_ID, 
      employee_ID: this.listOrders[0].employee.employee_ID,
    }
    this.ModelTitle="Add Order";
    this.ActivateAddEditEmpComp=true;
  }
  editClick(item:any)
  {
    this.order = item;
    this.ModelTitle="Edit Employee";
    this.ActivateAddEditEmpComp=true;
  }
  closeClick()
  {
    this.ActivateAddEditEmpComp=false;
    this.getOrderAll();
  }
  deleteClick(id:any)
  {
    if (confirm('Are you sure!')) {
      this.orderService.delete(id).subscribe((data:any)=>{
        alert("Delete Succcess");
        this.getOrderAll();
      })
    }
  }
}
