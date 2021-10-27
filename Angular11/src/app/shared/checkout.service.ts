import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartService } from './cart.service';
//import { CartComponent } from '../cart/cart.component';
import { UserService } from '../shared/user.service';
import { ThrowStmt } from '@angular/compiler';
import { OrderDetail } from './order-detail.model';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})


export class CheckoutService {
  readonly URL='http://localhost:59970/api/Orders/'
  readonly URLOrderDetail='http://localhost:59970/api/OrderDetails'
  public OrderData: any;
  public OrderDetail?: OrderDetail[];
  constructor(private http: HttpClient, private cartService:CartService, private userService:UserService) { }

  getNewOrderValue() {
    return this.http.get(this.URL + 'GetOrders');
  }




    SaveOrder() {
      var order = {
        OrderId: 0,
        OrderNumber: '00001',
        amount: this.cartService.getTotalPrice(),
        OrderDate: '1990-01-01',
        userId: this.userService.userId,
        OrderStatus:'NEW'
      };
    return   this.http.post<any>(this.URL + 'AddOrder', order)
  }
  SaveOrderDetail(orderdetail?:any) {
return this.http.post<any>(this.URLOrderDetail , orderdetail);
}

}





  
  
 

    
  

