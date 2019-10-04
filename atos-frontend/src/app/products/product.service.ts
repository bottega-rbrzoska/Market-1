import { Injectable } from '@angular/core';
import { Product } from '../models/product.interface';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class ProductService {
  private products: Product[] = [
    { id: '1', name: 'pomidor', description: 'opis pomidora', price: 1.99, category: 'warzywo'},
    { id: '2', name: 'ogorek', description: 'costam o ogorku', price: 0.99, category: 'warzywo'}
  ];
  private productsSubj = new BehaviorSubject<Product[]>(this.products);

  products$ = this.productsSubj.asObservable();
  constructor() { }
}
