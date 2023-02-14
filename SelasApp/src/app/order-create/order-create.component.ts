import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {
  orderForm: FormGroup;
  allCustomer:any[]=[];
  allProduct:any[]=[];
  allOrder:any[]=[];
  selectProduct:number[]=[];
  productPrices:number=0;
  totalPrices:number;
  cstId:number;


  constructor(
    public _OrderService:OrderService,
    private _fb:FormBuilder,
    private http:HttpClient
  ) { }

  ngOnInit(): void {
  this.getAllProduct();
  this.getAllCustomer();
  this.CreateItem();
  }

  getAllProduct(){
    this._OrderService.getAllProduct().subscribe(res=>{
      this.allProduct=res as any[];
      console.log("this.itemslists",this.allProduct);
    })
  }
  getAllCustomer(){
    this._OrderService.getAllCustomer().subscribe(res=>{
      this.allCustomer=res as any[];
      console.log("this.itemslists",this.allCustomer);
    })
  }
  getPrice(price:any){
    this.productPrices=price.productPrice;
  }
  totalPrice(ttlPrice:any){
   this.totalPrices=this.productPrices*ttlPrice;
  }

  saveOrder(){
    this.orderForm.value.totalPrice=this.totalPrices;
    this._OrderService.saveOrder(this.orderForm.value).subscribe((res:any)=>{
          this.CreateItem();
    })
  }

  getAllOrder(customerId:any){
      console.log("Get customer Id",customerId.id);
      this.cstId=customerId.id;

      this._OrderService.getAllOrder(customerId.id).subscribe((result:any)=>{
          this.allOrder=result as any[];

          console.log("this.allOrder",this.allOrder);
      })
  }
  invoicegnrt(){
     console.log("Invoice for id",this.cstId);
     this._OrderService.getReport(this.cstId).subscribe(res=>{
      let blob:Blob=res.body as Blob;
      let url=window.URL.createObjectURL(blob);
      window.open(url); 
    })
  }

  CreateItem(){
    this.orderForm=this._fb.group({
      id: [0,[]],
      customerId:[,[]],
      productId:[,[]],
      unit:[,[]],
      totalPrice:[,[]],
    })
  }

  get f(){
    return this.orderForm.value;
  }
}
