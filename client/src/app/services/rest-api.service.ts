import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RestAPIService {
  constructor(private http:HttpClient, private tokenStorage: TokenStorageService) { }
  getHeaders(){
    const token = this.tokenStorage.getToken();
    return token? new HttpHeaders().set('Authorization','Bearer '+token):null;
  }
  get(urlAPI:string)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.get(urlAPI,{headers:headers});
    }
    return this.http.get(urlAPI);
  }
  getOne(urlAPI:string,id: number)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.get(urlAPI+'/'+id,{headers:headers});
    }
    return this.http.get(urlAPI+'/'+id);
  }
  getByName(urlAPI:string,name: string)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.get(urlAPI+"?customer_Name="+name,{headers:headers});
    }
    return this.http.get(urlAPI+'/'+name);
  }
  post(urlAPI:string,body: any)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.post(urlAPI,body,{headers:headers});
    }
    return this.http.post(urlAPI,body);
  }
  put(urlAPI:string,body: any,id:number)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.put(urlAPI+'/'+id,body,{headers:headers});
    }
    return this.http.put(urlAPI+'/'+id,body);
  }
  delete(urlAPI:string,id:number)
  {
    let headers = this.getHeaders();
    if (headers instanceof HttpHeaders) {
      return this.http.delete(urlAPI+'/'+id,{headers:headers});
    }
    return this.http.delete(urlAPI+'/'+id);
  }
}
