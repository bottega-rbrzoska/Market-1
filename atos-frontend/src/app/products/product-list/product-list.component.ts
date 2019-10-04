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

  products: Product[] = [];
  products$: Observable<Product[]>;
  constructor(private productService: ProductService) {
    this.productService.products$.subscribe(
      prod => this.products = prod
    );
    this.products$ = this.productService.products$;
   }

  ngOnInit() {
  }

}
