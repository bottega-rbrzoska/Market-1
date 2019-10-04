import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductListItemComponent } from './product-list-item/product-list-item.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductFormComponent } from './product-form/product-form.component';


@NgModule({
  declarations: [ProductListComponent, ProductListItemComponent, ProductAddComponent, ProductEditComponent, ProductFormComponent],
  imports: [
    CommonModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }
