import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './test/test.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { PageNotFoundComponent } from './main/page-not-found/page-not-found.component';
import { HomeComponent } from './main/home/home.component';
import { ObservablesComponent } from './main/observables/observables.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test', component: TestComponent },
  { path: 'observables', component: ObservablesComponent },
  { path: 'users',  loadChildren: () => import('./user/user.module').then(m => m.UserModule) },
  { path: 'products',  loadChildren: () => import('./products/products.module').then(m => m.ProductsModule) },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
