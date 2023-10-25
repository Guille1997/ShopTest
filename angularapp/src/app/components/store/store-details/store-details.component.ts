import { Component, Input, OnInit } from '@angular/core';
import { StoreService } from '../../../services/store.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '../../../models/store.model';

@Component({
  selector: 'app-store-details',
  templateUrl: './store-details.component.html',
  styleUrls: ['./store-details.component.css']
})
export class StoreDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentStore: Store = {
    branch: '',
    address: ''
  };

  message = '';

  constructor(
    private storeService: StoreService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getStore(this.route.snapshot.params["id"]);

    }
  }

  getStore(id: any): void {
    this.storeService.get(id)
      .subscribe({
        next: (data) => {
          this.currentStore = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }



  updateStore(): void {
    this.message = '';

    this.storeService.update(this.currentStore.id, this.currentStore)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message ? res.message : 'This store was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteStore(): void {
    this.storeService.delete(this.currentStore.id)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/store']);
        },
        error: (e) => console.error(e)
      });
  }
}
