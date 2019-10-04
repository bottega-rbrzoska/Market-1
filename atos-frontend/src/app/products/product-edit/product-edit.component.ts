import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product.interface';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  constructor(productService: ProductService, private activatedRoute: ActivatedRoute) {
    productService.getProductById$(activatedRoute.snapshot.params.id).subscribe(prod => this.product = prod)
   }

  ngOnInit() {
  }

}
