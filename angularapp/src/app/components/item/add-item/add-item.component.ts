import { Component, OnInit } from '@angular/core';
import { Item } from '../../../models/item.model';
import { ItemService } from '../../../services/item.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit{
  item: Item = {
    description : '',
    price: '',
    image: '',
    stock: '',
  }

  submitted = false;

  constructor(private itemService: ItemService) { }

  ngOnInit(): void {
  }

  saveItem(): void {
    const data = {
      description: this.item.description,
      price: this.item.price,
      image: this.item.image,
      stock: this.item.stock
    };

    this.itemService.create(data).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.submitted = true;
        },
        error: (e) => console.error(e)
      });
  }

  newItem(): void {
    this.submitted = false;
    this.item = {
      description: '',
      price: '',
      image: '',
      stock: '',
    }
  }
}
