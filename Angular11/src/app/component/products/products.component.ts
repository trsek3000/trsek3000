
import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/shared/cart.service';
import { Product } from 'src/app/shared/product.model';
import { ProductService } from 'src/app/shared/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public productList : any;

  constructor(private api: ProductService, private cartService : CartService) { }


  
  ngOnInit(): void {
    this.api.GetAllProduct()
    .subscribe(res=>{
      this.productList = res;
      this.productList.forEach((a:any) => {
        if(a.category ==="women's clothing" || a.category ==="men's clothing"){
          a.category ="fashion"
        }
        Object.assign(a,{quantity:1,total:a.price});
      });
      console.log(this.productList)
    });
}
addtocart(item: any){
  this.cartService.addtoCart(item);
}
}
