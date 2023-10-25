import { Component, Input, OnInit } from '@angular/core';
import { Item } from '../../../models/item.model';
import { ItemService } from '../../../services/item.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentItem: Item = {
    description: '',
    price: '',
    image: '',
    stock : ''
  };

  message = '';

  constructor(
    private itemService: ItemService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getItem(this.route.snapshot.params["id"]);

    }
  }

  getItem(id: any): void {
    this.itemService.get(id)
      .subscribe({
        next: (data) => {
          this.currentItem = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }



  updateItem(): void {
    this.message = '';

    this.itemService.update(this.currentItem.code, this.currentItem)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message ? res.message : 'This item was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteItem(): void {
    this.itemService.delete(this.currentItem.code)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/item']);
        },
        error: (e) => console.error(e)
      });
  }
}
