import { Component, OnInit } from '@angular/core';
import { Store } from '../../../models/store.model';
import { StoreService } from '../../../services/store.service';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.css']
})
export class StoreListComponent implements OnInit {
  stores?: Store[];
  currentStore: Store = {};
  currentIndex = -1;

  constructor(private storeService: StoreService) {
    
  }

  ngOnInit(): void {
    this.retrieveStores();
  }
  retrieveStores(): void {
    this.storeService.getAll().subscribe({
      next: (data) => {
        this.stores = data;

        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  refreshList(): void {
    this.retrieveStores();
    this.currentStore = {};
    this.currentIndex = -1;
  }

  setActiveStore(store: Store, index: number): void {
    this.currentStore = store;
    this.currentIndex = index;
  }

}
