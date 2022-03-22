import { Injectable } from '@angular/core';
import { RestAPIService } from './rest-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService{

  readonly urlAPI = "https://localhost:44348/api/Customers";
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
  getByName(name:string)
  {
    return this.restService.getByName(this.urlAPI,name);
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
