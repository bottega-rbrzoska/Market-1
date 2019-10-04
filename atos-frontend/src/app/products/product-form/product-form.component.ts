import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { Product } from 'src/app/models/product.interface';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {

  @Output() save = new EventEmitter();
  @Input() product: Product;

  productsForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    price: new FormControl(0, [Validators.required, Validators.max(200)]),
    category: new FormControl('', {
      validators: [Validators.required, this.assValidator]
    })
  });
  constructor() { }

  ngOnInit() {
    if (this.product) {
      this.productsForm.patchValue(this.product);
    }
    this.productsForm.valueChanges.subscribe(vals => console.log(vals))
  }

  private assValidator(control: AbstractControl): ValidationErrors | null {
    return control.value.includes('ass') ||  control.value.includes('dupa') ? {
      badWord: true
    } : null;
  }

  handleSave() {
    if (this.productsForm.valid) {
      this.save.emit(this.productsForm.value)
    }
  }

}
