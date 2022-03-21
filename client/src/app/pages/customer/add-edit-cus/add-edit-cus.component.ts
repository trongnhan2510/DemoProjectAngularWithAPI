import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/Models/Customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-add-edit-cus',
  templateUrl: './add-edit-cus.component.html',
  styleUrls: ['./add-edit-cus.component.css']
})
export class AddEditCusComponent implements OnInit {
  @Input() cus:any;
  customer_ID!:number;
  customer_Name!:string;
  address!:string;
  telephone!:string;
  index:number = 0;
  
  constructor( private customerService: CustomerService) { 
  }
  ngOnInit(): void {
    this.customer_ID = this.cus.customer_ID,
    this.customer_Name = this.cus.customer_Name,
    this.address = this.cus.address,
    this.telephone = this.cus.telephone
  }
  addCustomer()
  {
    var val = {
      customer_Name:this.customer_Name,
      address:this.address,
      telephone:this.telephone
    }
    this.customerService.add(val).subscribe((data:any)=>{
      alert("Add new Customer Success");
      window.location.reload();
    });
  }
  updateCustomer(){
    var val = {customer_ID:this.customer_ID,
      customer_Name:this.customer_Name,
      address:this.address,
      telephone:this.telephone
    };
    this.customerService.update(this.customer_ID,val).subscribe((data:any)=>{
      alert("Edit new Customer Success");
      window.location.reload();
    });
  }
}
