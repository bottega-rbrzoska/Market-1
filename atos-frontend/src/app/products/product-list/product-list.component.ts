import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from 'src/app/models/product.interface';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { debounce, debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  searchFormControl = new FormControl('');
  products$: Observable<Product[]>;
  constructor(private productService: ProductService) {
    this.products$ = this.productService.products$;
    this.productService.fetchProducts();
   }

  ngOnInit() {
    this.searchFormControl.valueChanges
    .pipe(
      debounceTime(300)
    )
    .subscribe(value => {
      this.productService.fetchFilteredProducts(value);
    });
  }

  deleteProduct(id) {
    this.productService.deleteProduct(id).subscribe(
      () => this.productService.fetchProducts(),
      error => alert(JSON.stringify(error)));
  }

}
