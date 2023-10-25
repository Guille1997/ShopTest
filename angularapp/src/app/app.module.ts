import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ClientComponent } from './components/client/client.component';
import { ClientDetailsComponent } from './components/client-details/client-details.component';
import { AddClientComponent } from './components/add-client/add-client.component';
import { AddItemComponent } from './components/item/add-item/add-item.component';
import { ItemDetailsComponent } from './components/item/item-details/item-details.component';
import { ItemListComponent } from './components/item/item-list/item-list.component';
import { AddStoreComponent } from './components/store/add-store/add-store.component';
import { StoreDetailsComponent } from './components/store/store-details/store-details.component';
import { StoreListComponent } from './components/store/store-list/store-list.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    AddClientComponent,
    ClientDetailsComponent,
    AddItemComponent,
    ItemDetailsComponent,
    ItemListComponent,
    AddStoreComponent,
    StoreDetailsComponent,
    StoreListComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule, HttpClientModule, AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
