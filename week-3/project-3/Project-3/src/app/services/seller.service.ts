import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { signUp, login } from '../data-type';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class SellerService {
  isSellerLoggedIn = new BehaviorSubject<boolean>(false)
  isLoginError = new EventEmitter<boolean>(false)
  constructor(private http: HttpClient, private router: Router) { }
  //this function will help to post the data in the database.
  userSignUp(data: signUp) {
    // console.warn("service call")
    //this link we get after installing json server after create the db.json file and paste this command json-server --watch db.json
    //after that call this function in componet.ts file using constructor.
    let result = this.http.post('http://localhost:3000/seller', data, { observe: 'response' })
      .subscribe((result) => {
        this.isSellerLoggedIn.next(true);
        //to save the data in localstorage Inspect->Application->localstorage
        localStorage.setItem('seller', JSON.stringify(result.body))

        this.router.navigate(['seller']);
        console.warn("result", result);
      });
    // return false;
  }
  reloadSeller() {
    if (localStorage.getItem('seller')) {
      this.isSellerLoggedIn.next(true);
      this.router.navigate(['seller-home']);
    }
  }

  // userLogin(data:login){
  //   this.http.get(`http://localhost:3000/seller?email=${data.email}&password=${data.password}`,
  //   {observe:'response'}).subscribe((result:any)=>{
  //    console.warn(result)
  //    if(result && result.body && result.body.length===1){
  //      this.isLoginError.emit(false)
  //      localStorage.setItem('seller',JSON.stringify(result.body))
  //      this.router.navigate(['seller-home'])
  //    }






  userLogin(data: login) {
    // console.warn(data)
    //api call code will be there
    this.http.get(`http://localhost:3000/seller?email=${data.email}&password=${data.password}`,
      { observe: 'response' }
    ).subscribe((result: any) => {
      console.warn(result)
      if (result && result.body && result.body.length) {
        console.warn("Item added successfully")
        localStorage.setItem('seller', JSON.stringify(result.body))
        this.router.navigate(['seller-home']);
      } else {
        console.warn("Failed to add item")
        this.isLoginError.emit(true)
      }
    });

  }
}
