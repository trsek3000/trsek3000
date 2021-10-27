import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/shared/cart.service';
import { UserService } from 'src/app/shared/user.service';
import { HttpClient } from '@angular/common/http';
import { CheckoutService } from 'src/app/shared/checkout.service';
import { DatePipe } from '@angular/common';
import { Observable, of } from 'rxjs';
import { OrderDetail } from 'src/app/shared/order-detail.model';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';




@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit {
 
  readonly URL='http://localhost:59970/api/Orders'
  myDate = new Date();
  constructor(private cart:CartService,private userService:UserService, private checkout:CheckoutService) { }
  public products : any = [];
  public grandTotal !: number;
  public OrderData: any;

  public OrderId : any



   orderdetail: any  = {
    OrderDetailId:0,
    OrderId: 0,
    Price: 0,
    Quantity:0,
    ProductId : 0

   }



  ngOnInit(): void {
    this.cart.getProducts()
    .subscribe(res=>{
      this.products = res;
      this.grandTotal = this.cart.getTotalPrice();
    })
  }

 
  removeItem(item: any){
    this.cart.removeCartItem(item);
  }
  emptycart(){
    this.cart.removeAllCart();
  }


  SaveOrder(){
   
   this.checkout.SaveOrder()
   .subscribe(
      res1 => {
         this.OrderId = res1
    
         this.cart.cartItemList.map((res:any) => {
           this.OrderId = res1
            this.orderdetail.ProductId  = res.productId
            this.orderdetail.OrderId = res1,
            this.orderdetail.OrderNumber = res.OrderNumber
            this.orderdetail.Price = res.price
            this.orderdetail.Quantity = res.quantity
            this.checkout.SaveOrderDetail(this.orderdetail).subscribe()
            console.log(this.orderdetail)
         })
        
          
        })
        
  
  }

  
}