import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './components/client/client.component';
import { ClientDetailsComponent } from './components/client-details/client-details.component';
import { AddClientComponent } from './components/add-client/add-client.component';
import { ItemListComponent } from './components/item/item-list/item-list.component';
import { AddItemComponent } from './components/item/add-item/add-item.component';
import { ItemDetailsComponent } from './components/item/item-details/item-details.component';
import { StoreListComponent } from './components/store/store-list/store-list.component';
import { AddStoreComponent } from './components/store/add-store/add-store.component';
import { StoreDetailsComponent } from './components/store/store-details/store-details.component';


const routes: Routes = [
  {path : '' , redirectTo : 'client', pathMatch: 'full'},
  { path: 'client', component: ClientComponent },
  { path: 'client/add', component: AddClientComponent },
  { path: 'client/:id', component: ClientDetailsComponent },
  { path: 'item', component: ItemListComponent },
  { path: 'item/add', component: AddItemComponent },
  { path: 'item/:id', component: ItemDetailsComponent },
  { path: 'store', component: StoreListComponent },
  { path: 'store/add', component: AddStoreComponent },
  { path: 'store/:id', component: StoreDetailsComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
