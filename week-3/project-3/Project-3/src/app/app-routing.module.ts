import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SellerAuthComponent } from './seller-auth/seller-auth.component';
import { SellerHomeComponent } from './seller-home/seller-home.component';
// import { AuthGuard } from './auth.guard';
import { HeaderComponent } from './header/header.component';
import { SellerAddProductComponent } from './seller-add-product/seller-add-product.component';
import { SellerUpdateProductComponent } from './seller-update-product/seller-update-product.component';
import { SearchComponent } from './search/search.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { UserAuthComponent } from './user-auth/user-auth.component';
//import { canActivate, canActivateChild } from './auth.guard';


const routes: Routes = [
  //This Speicify the routing of the Project When Create big Project then Routing is very important topic
  {
    component: HomeComponent,
    path: '',

  },
  {
    component: SellerAuthComponent,
    path: 'seller-auth',

  },
  {
    component: HomeComponent,
    path: 'home',

  },
  {
    component: SellerHomeComponent,
    path: 'seller-home',
    // canActivate: [AuthGuard]


  },
  {
    component: HeaderComponent,
    path: 'header',
  },
  {
    component: SellerAddProductComponent,
    path: 'seller-add-product',
    // canActivate: [AuthGuard]
    //canActivateChild: [canActivateChild]
  },
  {
    component: SellerUpdateProductComponent,
    path: 'seller-update-product/:id',
    // canActivate: [AuthGuard]
    //canActivateChild: [canActivateChild]
  },
  {
    component: SearchComponent,
    path: 'search/:query',
    // canActivate: [AuthGuard]
    //canActivateChild: [canActivateChild]
  },
  {
    component: ProductDetailsComponent,
    path: 'details/:productId',
    // canActivate: [AuthGuard]
    //canActivateChild: [canActivateChild]
  },
  {
    component: UserAuthComponent,
    path: 'user-auth',
    // canActivate: [AuthGuard]
    //canActivateChild: [canActivateChild]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
