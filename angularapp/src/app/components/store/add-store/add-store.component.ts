import { Component, OnInit } from '@angular/core';
import { Store } from '../../../models/store.model';
import { StoreService } from '../../../services/store.service';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent implements OnInit {
  store: Store = {
    branch: '',
    address : ''
  }

  submitted = false;

  constructor(private storeService: StoreService) {

  }

  ngOnInit(): void {

  }
  saveStore(): void {
    const data = {
      branch: this.store.branch,
      address: this.store.address,
    };

    this.storeService.create(data).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.submitted = true;
        },
        error: (e) => console.error(e)
      });
  }

  newStore(): void {
    this.submitted = false;
    this.store = {
      branch: '',
      address: ''
    }
  }


}
