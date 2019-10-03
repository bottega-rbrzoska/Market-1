import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VatPipe } from './vat.pipe';



@NgModule({
  declarations: [
    VatPipe],
  imports: [
    CommonModule
  ],
  exports: [VatPipe]
})
export class SharedModule { }
