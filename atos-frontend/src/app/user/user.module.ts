import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { UserListItemComponent } from './user-list-item/user-list-item.component';
import { UserService } from './user.service';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: UserListComponent }
];

@NgModule({
  declarations: [
    UserListComponent,
    UserListItemComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  providers: [UserService]
})
export class UserModule { }
