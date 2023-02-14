import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseApiUrl: string = environment.apiUrl;
  constructor(private http:HttpClient) { }

  getAllProduct(){
    return this.http.get(this.baseApiUrl+'/api/Product/GetAllProducts');
  }
  getAllCustomer(){
    return this.http.get(this.baseApiUrl+'/api/Product/GetAllCustomer');
  }
  saveOrder(order:any){
    console.log("order",order);
  return this.http.post(this.baseApiUrl+'/api/Product/CreatOrder',order);
  }
  getAllOrder(customerId:number){
    console.log("Get customer Id",customerId);
    return this.http.get(this.baseApiUrl+'/api/Product/GetAllOrder/'+customerId);
  }
  getReport(id:any){
    return this.http.get(this.baseApiUrl+'/api/Product/GetReport/'+id,{observe:'response',responseType:'blob'});
  }
}
