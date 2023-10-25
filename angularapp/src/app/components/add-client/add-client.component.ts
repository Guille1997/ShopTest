import { Component, OnInit } from '@angular/core';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {
  client: Client = {
    name: '',
    lastName: '',
    address: ''
  };

  submitted = false;

  constructor(private clientService: ClientService) {

  }

  ngOnInit(): void {
  }

  saveClient(): void {
    const data = {
      name: this.client.name,
      lastName: this.client.lastName,
      address: this.client.address,
    };

    this.clientService.create(data).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.submitted = true;
        },
        error: (e) => console.error(e)
      });
  }

  newClient(): void {
    this.submitted = false;
    this.client = {
      name: '',
      lastName: '',
      address: ''
    }
  }

}
