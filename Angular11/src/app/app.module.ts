import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import{ HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { HeaderComponent } from './component/header/header.component';
import { CartComponent } from './component/cart/cart.component';
import { ProductsComponent } from './component/products/products.component';
import { ProductService } from './shared/product.service';
import { UserRegisterationComponent } from 'src/app/component/user-registration/user-registration.component';
import { UserLoginComponent } from 'src/app/component/user-login/user-login.component';
import { OrderComponent } from './component/order/order.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CartComponent,
    ProductsComponent,
    UserLoginComponent,
    UserRegisterationComponent,
    OrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    BrowserAnimationsModule
  ],

  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
