import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductFormComponent } from './product-form.component';

describe('ProductFormComponent', () => {
  let component: ProductFormComponent;

  beforeEach(() => {
    component = new ProductFormComponent();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  it('should set form as invalid for empty name', () => {
    component.productsForm.setValue({
      name: null,
      price: 10,
      description: 'test',
      category: 'test'
    });
    expect(component.productsForm.invalid).toBe(true);
  });
});
