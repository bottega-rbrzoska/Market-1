import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestService } from './test.service';
import { TestComponent } from './test.component';
import { TestDirective } from './test.directive';



@NgModule({
  declarations: [
    TestComponent,
    TestDirective],
  imports: [
    CommonModule
  ],
  providers: [TestService]
})
export class TestModule { }
