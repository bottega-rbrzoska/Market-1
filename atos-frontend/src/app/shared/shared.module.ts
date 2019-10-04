import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VatPipe } from './vat.pipe';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    VatPipe],
  imports: [
    CommonModule,
    NgbAlertModule
  ],
  exports: [
    VatPipe,
    NgbAlertModule]
})
export class SharedModule { }
