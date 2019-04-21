import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { CarouselComponent } from './carousel/carousel.component';
import { BrandComponent } from './brand/brand.component';
import { RecommendationComponent } from './recommendation/recommendation.component';
import { SaleComponent } from './sale/sale.component';
import { CommentComponent } from './comment/comment.component';
import { ShutterComponent } from './shutter/shutter.component';
import { HomeContainerComponent } from './home-container/home-container.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CategoryComponent } from './category/category.component';
import { ItemComponent } from './item/item.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { OrdersComponent } from './orders/orders.component';
import { GameDialogComponent } from './game-dialog/game-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    CarouselComponent,
    BrandComponent,
    RecommendationComponent,
    SaleComponent,
    CommentComponent,
    ShutterComponent,
    HomeContainerComponent,
    LoginComponent,
    RegisterComponent,
    CategoryComponent,
    ItemComponent,
    CartComponent,
    CheckoutComponent,
    OrderDetailComponent,
    OrdersComponent,
    GameDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
