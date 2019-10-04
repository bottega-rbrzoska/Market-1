import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.interface';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private router: Router) {
    productService.getProductById$(activatedRoute.snapshot.params.id).subscribe(prod => this.product = prod)
   }

  ngOnInit() {
  }
  handleSaveForm(product) {
    product.id = this.product.id;
    this.productService.addProduct(product).subscribe(() => {
      this.router.navigateByUrl('/products');
      this.productService.fetchProducts();
    }, error => alert(JSON.stringify(error)));
  }

}
