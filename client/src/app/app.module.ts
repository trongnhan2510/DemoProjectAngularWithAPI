import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { ShowCusComponent } from './pages/customer/show-cus/show-cus.component';
import { AddEditCusComponent } from './pages/customer/add-edit-cus/add-edit-cus.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { DatePipe } from '@angular/common';
import { OrderComponent } from './pages/order/order.component';
import { ShowOrderComponent } from './pages/order/show-order/show-order.component';
import { AddEditOrderComponent } from './pages/order/add-edit-order/add-edit-order.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { ShowEmpComponent } from './pages/employee/show-emp/show-emp.component';
import { AddEditEmpComponent } from './pages/employee/add-edit-emp/add-edit-emp.component';
import { LoginComponent } from './pages/login/login.component';
import { OrderService } from './services/order.service';
import { EmployeeService } from './services/employee.service';
import { HomeComponent } from './pages/home/home.component';
import { CustomerService } from './services/customer.service';
import { LoginService } from './services/login.service';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    ShowEmpComponent,
    AddEditEmpComponent,
    CustomerComponent,
    ShowCusComponent,
    AddEditCusComponent,
    OrderComponent,
    ShowOrderComponent,
    AddEditOrderComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [DatePipe,OrderService,EmployeeService,CustomerService,LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
