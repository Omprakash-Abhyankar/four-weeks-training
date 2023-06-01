import { Component, OnInit } from '@angular/core';
import { SellerService } from '../services/seller.service';
import { Router } from '@angular/router';
import { signUp, login } from '../data-type';
@Component({
  selector: 'app-seller-auth',
  templateUrl: './seller-auth.component.html',
  styleUrls: ['./seller-auth.component.css']
})
export class SellerAuthComponent implements OnInit{
    constructor(private seller:SellerService, private router:Router) {}
    showLogin=true;
    authError:string='';
    ngOnInit():void{
      this.seller.reloadSeller()
    }
    signUp(data:signUp): void{
       console.warn(data)
       this.seller.userSignUp(data)
      // .subscribe((result)=>{
        // console.warn(result);
        if(data){
        //this.router.navigate(['home'])
        //this.showLogin=true;
        }
      // });
    }

    login(data:login): void{
      this.authError="";
      // console.warn(data)
       //this.seller.userSignUp(data)
       this.seller.userLogin(data)
       this.seller.isLoginError.subscribe((isError)=>{
        if (isError){
          this.authError="Invalid Credintial!.";
          this.router.navigate(['/home'])
        }else{

        }
       });
    }
    openLogin(){
    this.showLogin=true;
    //this.router.navigate(['seller-home']);

    }
    openSignUp(){
      this.showLogin=false;
    }
}
