import { Component, OnInit, Input, DoCheck, Output } from '@angular/core';
import { DatePipe } from '@angular/common';
import { OrderService } from 'src/app/services/order.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-add-edit-order',
  templateUrl: './add-edit-order.component.html',
  styleUrls: ['./add-edit-order.component.css']
})
export class AddEditOrderComponent implements OnInit {
  @Input() order:any;
  order_ID!:number;
  saleofDate!:any;
  total!:number;
  customer_ID!:number;
  employee_ID!:number;  
  listCustomer!:any;
  listEmployee!:any;
  errorMessage:any;
  constructor(private orderService: OrderService, private datePipe: DatePipe, private empService: EmployeeService, private cuservice: CustomerService) { }
  ngOnInit(): void {
    this.getCustomerAll();
    this.getEmployeeAll();
    this.order_ID = this.order.order_ID;
    this.saleofDate = this.datePipe.transform(this.order.saleofDate, 'yyyy-MM-dd');
    this.total = this.order.total;
    this.customer_ID = this.order.customer_ID;
    this.employee_ID = this.order.employee_ID;
  }
  getCustomerAll()
  {
    this.cuservice.get().subscribe((data:any)=>{
      this.listCustomer = data;
    }); 
  }
  getEmployeeAll()
  {
    this.empService.get().subscribe((data:any)=>{
      this.listEmployee = data;
    });
  }
  selectChangeHandlerCus(event:any){
    this.customer_ID = event.target.value;
  }
  selectChangeHandlerEmp(event:any)
  {
    this.employee_ID = event.target.value;
  }
  addOrder()
  {
    var order = {
      saleofDate:this.saleofDate,
      total:this.total,
      customer_ID:this.customer_ID,
      employee_ID:this.employee_ID,
    };
    if (order.saleofDate > Date.now()) {
      this.errorMessage =  "Sale date must be less than or equal to current date";
    }
    this.orderService.add(order).subscribe((data:any)=>{
      alert("Add new Order Success");
      window.location.reload();
    });
  } 
  updateOrder(){
    var order = {
      order_ID:this.order_ID,
      saleofDate:this.saleofDate,
      total:this.total,
      customer_ID:this.customer_ID,
      employee_ID:this.employee_ID,
    };
    console.log(order);
    this.orderService.update(order.order_ID,order).subscribe((data:any)=>{
      alert("Edit new Order Success");
      window.location.reload();
    });
  }
}
