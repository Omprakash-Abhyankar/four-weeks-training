import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../services/product.service';
import { cart, product } from '../data-type';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  productData: undefined | product;
  productQuantity: number = 1;
  removeCart = false;
  cartData: undefined| product;
  constructor(
    private activeRoute: ActivatedRoute,
    private product: ProductService
  ) {}
  ngOnInit(): void {
    // activeRoute: Refers to an instance of the ActivatedRoute class, which is part of the Angular Router module
    // snapshot : The ActivatedRoute has a property called snapshot,
    // which represents a static image of the route at a particular moment in time.
    // paramMap: Refers to the parameter map of the current route's snapshot.
    // The paramMap property of snapshot holds a ParamMap object that maps parameter names to their corresponding values.
    let productId = this.activeRoute.snapshot.paramMap.get('productId');
    console.warn(productId);
    productId &&
      this.product.getProduct(productId).subscribe((result) => {
        console.warn(result);
        this.productData = result;

        let cartData = localStorage.getItem('localCart');
        if (productId && cartData) {
          let items = JSON.parse(cartData);
          //filter function array ke andar ki keys ki value ko nikal sakata hai.
          //single line function or arrow function
          items = items.filter(
            (item: product) => productId == item.id.toString()
          );
          if (items.length) {

            this.removeCart = true;

          } else {
            this.removeCart = false;
          }
        }
      });

    let user = localStorage.getItem('user');

    if (user) {
      let userId = user && JSON.parse(user).id;
      //update carlist after refresh
      this.product.getCartList(userId);
      this.product.cartData.subscribe((result) => {
        let item = result.filter(
          (item: product) =>
            productId?.toString() === item.productId?.toString()
        );
        if (item.length) {
          this.cartData=item[0];
          this.removeCart = true;
        }
      });
    }
  }

  handleQuantity(val: string) {
    if (this.productQuantity < 20 && val === 'plus') {
      this.productQuantity += 1;
    } else if (this.productQuantity > 1 && val === 'min') {
      this.productQuantity -= 1;
    }
  }
  addToCart() {
    if (this.productData) {
      this.productData.quantity = this.productQuantity;
      //add to cart without login
      if (!localStorage.getItem('user')) {
        // console.warn(this.productData);
        this.product.localAddToCart(this.productData);
        this.removeCart = true;
      } else {
        //console.warn("user is Logged in");
        let user = localStorage.getItem('user');
        let userId = user && JSON.parse(user).id;
        //console.warn(userId);
        let cartData: cart = {
          ...this.productData,
          userId,
          productId: this.productData.id,
        };
        delete cartData.id;
        // console.warn(cartData);
        this.product.addToCart(cartData).subscribe((result) => {
          //console.warn(result);
          if (result) {
            //alert('Product is added in cart')
            //dyanmically update navbar cart
            this.product.getCartList(userId);
            //show remove button after clicking add to cart
            this.removeCart = true;
          }
        });
      }
    }
  }
  removeToCart(productId: number) {
    if (!localStorage.getItem('user')) {
      this.product.removeItemFromCart(productId);

    } else {
      let user = localStorage.getItem('user');
      let userId = user && JSON.parse(user).id;
      console.warn(this.cartData);
     this.cartData && this.product.removeToCart(this.cartData.id)
     .subscribe((result) => {
      if(result){
        this.product.getCartList(userId);
      }
     });
     this.removeCart = false;
    }
  }
}
