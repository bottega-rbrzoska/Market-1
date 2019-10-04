import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { ObservablesComponent } from './observables/observables.component';

@NgModule({
  declarations: [
    HomeComponent,
    NavigationComponent,
    PageNotFoundComponent,
    ObservablesComponent],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule
  ],
  exports: [NavigationComponent]
})
export class MainModule { }
