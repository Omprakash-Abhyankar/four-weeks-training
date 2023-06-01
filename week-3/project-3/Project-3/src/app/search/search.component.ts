import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../services/product.service';
import { product } from '../data-type';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  searchResult: undefined | product[];
  // creating Instance in the Constructor
  constructor(
    private activeRoute: ActivatedRoute,
    private product: ProductService
  ) {}

  // activeRoute: Refers to an instance of the ActivatedRoute class, which is part of the Angular Router module
  // snapshot : The ActivatedRoute has a property called snapshot, which represents a static image of the route at a particular moment in time.
  ngOnInit(): void {
    //this get form app.routing file because we define its path search/:query
    //whatever we write in routing file (query) that name we will get here
    let query = this.activeRoute.snapshot.paramMap.get(`query`);
    console.warn(query);
    //subscribe is gives us the callback result
    query &&
      this.product.searchProducts(query).subscribe((result) => {
        // console.warn(result);
        this.searchResult = result;
      });
  }
}
