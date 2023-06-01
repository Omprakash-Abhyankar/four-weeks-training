import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { product } from '../data-type';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  menuType: String = 'default';
  sellerName: string = "";
  searchResult: undefined | product[];
  userName: string = "";
  cartItems = 0;
  constructor(private route: Router, private product: ProductService) { }
  ngOnInit(): void {
    this.route.events.subscribe((val: any) => {
      console.warn(val.url)
      if (val.url) {
        //If the Seller Login then Console in seller area that means that data store in Seller Localstorage
        if (localStorage.getItem('seller') && val.url.includes('seller')) {
          console.warn("in seller area");
          this.menuType = "seller";
          if (localStorage.getItem('seller')) {
            let sellerStore = localStorage.getItem('seller');
            //For converting JSON data in string form
            let sellerData = sellerStore && JSON.parse(sellerStore)[0];
            //first we intialise sellerName as string after that we saved data in sellerName
            this.sellerName = sellerData.name;
            console.warn(this.sellerName);
            this.menuType = 'seller';
          }
        } else if (localStorage.getItem('user')) {
          let userStore = localStorage.getItem('user');
          let userData = userStore && JSON.parse(userStore);
          this.userName = userData.name;
          this.menuType = 'user';
          this.product.getCartList(userData.id)
        }
        else {
          //Those data who is not store in seller locastorage
          //we console this in seller & outside seller because because we want to change the navbar dynamically using these console
          console.warn("outside seller");
          this.menuType = 'default';
        }
      }
    });

    let cartData = localStorage.getItem('localCart');
    if(cartData){
      this.cartItems= JSON.parse(cartData).length
    }
//add to cart
    this.product.cartData.subscribe((items) => {
      this.cartItems=items.length
        });
  }
  //for Logout
  logout() {
    localStorage.removeItem('seller');
    this.route.navigate(['/']);
  }
  userLogout() {
    localStorage.removeItem('user');
    this.route.navigate(['/user-auth']);
    this.product.cartData.emit([]);
  }
  //when we try try to search something on search box it gives the suggestion of data which contain that type of words.
  // KeyboardEvent keyword handles the keyword search on search bar
  searchProduct(query: KeyboardEvent) {
    if (query) {
      //
      const element = query.target as HTMLInputElement;
      // console.warn(element.value);
      //product which is define in data-type folder for declaring datatype of value & searchProducts function
      //get the data from database which is define in service
      //subscribe is a method that allows you to observe and react to the values emitted by an Observable
      this.product.searchProducts(element.value).subscribe((result) => {
        //console.warn(result);
        // this.searchResult=result;
        //showing only 5 searchbar result suggestion
        if (result.length > 5) {
          result.length = 5;
        }
        this.searchResult = result;
      });
    }
  }
  hideSearch() {
    this.searchResult = undefined;
  }
  redirectToDetails(id: number) {
    this.route.navigate(['/details/' + id]);
  }

  submitSearch(val: string) {
    //val param get the value which seller put in the searchbar.
    //we define this function in
    console.warn(val);
    this.route.navigate([`search/${val}`])

  }
}
