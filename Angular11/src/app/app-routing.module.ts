import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './component/cart/cart.component';
import { ProductsComponent } from './component/products/products.component';
import { UserLoginComponent } from './component/user-login/user-login.component';
import { UserRegisterationComponent } from './component/user-registration/user-registration.component';
import { OrderComponent } from './component/order/order.component';






const routes: Routes = [
  { path: '', component: UserLoginComponent, pathMatch: 'full' },
  { path: 'user-registration', component: UserRegisterationComponent },
  { path: 'user-login', component: UserLoginComponent },
  {path:'products', component: ProductsComponent},
  {path:'cart', component: CartComponent},
  {path:'order', component: OrderComponent}
  


];


@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
