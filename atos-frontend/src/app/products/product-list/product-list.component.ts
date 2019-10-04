import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from 'src/app/models/product.interface';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  products$: Observable<Product[]>;
  constructor(private productService: ProductService) {
    this.products$ = this.productService.products$;
    this.productService.fetchProducts();
   }

  ngOnInit() {
  }

}
