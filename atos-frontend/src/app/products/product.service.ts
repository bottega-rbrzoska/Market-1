import { Injectable } from '@angular/core';
import { Product } from '../models/product.interface';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class ProductService {
  private productsSubj = new BehaviorSubject<Product[]>([]);

  products$ = this.productsSubj.asObservable();
  productsNumber$ = this.productsSubj.pipe(
    map(prods => prods.length)
    );

  constructor(private httpClient: HttpClient) { }

  fetchProducts() {
    this.httpClient.get<Product[]>('http://localhost:5000/api/products')
    .subscribe(prods => this.productsSubj.next(prods));
  }

  fetchFilteredProducts(category: string) {
    this.httpClient.get<Product[]>('http://localhost:5000/api/products', {
      params: { category }
    })
    .subscribe(prods => this.productsSubj.next(prods));
  }

  getProductById$(id: string) {
    return this.httpClient.get<Product>('http://localhost:5000/api/products/' + id);
  }

  addProduct(prod) {
    return this.httpClient.post('http://localhost:5000/api/products', prod);
  }
}
