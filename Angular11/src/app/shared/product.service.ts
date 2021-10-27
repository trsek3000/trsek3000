import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from './product.model';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  
  readonly URL='http://localhost:59970/api/'

  constructor(private http: HttpClient) { }
  
  GetAllProduct(){
   return this.http.get<Product>(this.URL + 'Products')
    .pipe(map((res:Product)=>{
      return res;
    }))
  }


}
