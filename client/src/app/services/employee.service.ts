import { Injectable } from '@angular/core';
import { RestAPIService } from './rest-api.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService{

  readonly urlAPI = "https://localhost:44348/api/Employees";
  constructor(private restService: RestAPIService) {
  }
  get()
  {
    return this.restService.get(this.urlAPI);
  }
  getByID(id:number)
  {
    return this.restService.getOne(this.urlAPI,id);
  }
  add(order:any)
  {
    return this.restService.post(this.urlAPI,order);
  }
  update(id:number,order:any)
  {
    return this.restService.put(this.urlAPI,order,id);
  }
  delete(id:number)
  {
    return this.restService.delete(this.urlAPI,id);
  }
}
