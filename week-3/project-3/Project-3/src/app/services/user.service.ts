import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { login, signUp } from '../data-type';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  invalidUserAuth= new EventEmitter<boolean>(false)
  constructor(private http: HttpClient, private router:Router) { }
  userSignUp(user:signUp){
    // {observe:'response'}: This is an optional configuration object passed as the third argument to the post method. 
    // It specifies that the client wants to observe the full HTTP response, including the response headers and status code.
    //  By default, the post method may only return the response body. The observe property set to 'response' enables the desired behavior.
   this.http.post('http://localhost:3000/users',user,{observe:'response'})
   .subscribe((result)=>{
    if(result){
      // JSON.stringify is a JavaScript function that converts a JavaScript object or value into a JSON string. 
      // In this case, it is used to convert the result.body object into a JSON string representation.
      localStorage.setItem('user',JSON.stringify(result.body));
      this.router.navigate(['/']);
    }

   })

  }
  userLogin(data:login){
    this.http.get<signUp[]>(`http://localhost:3000/users?email=${data.email}&password=${data.password}`,
    {observe:'response'}
    ).subscribe((result)=>{
      if(result && result.body?.length){
        localStorage.setItem('user',JSON.stringify(result.body[0]));
        this.router.navigate(['/']);
        this.invalidUserAuth.emit(false)
      }else{
        this.invalidUserAuth.emit(true)
      }
    })
  }
//when user is logged in and try to access user login page by url without logout
//this function will route the user to home and restrict.
  userAuthReload(){
    if(localStorage.getItem('user')){
      this.router.navigate(['/']);
    }
  }
}
