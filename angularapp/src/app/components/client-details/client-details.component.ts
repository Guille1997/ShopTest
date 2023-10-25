import { Component, Input, OnInit } from '@angular/core';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styleUrls: ['./client-details.component.css']
})
export class ClientDetailsComponent implements OnInit{
  
  @Input() viewMode = false;

  @Input() currentClient: Client = {
    name: '',
    lastName: '',
    address: ''
  };

  message = '';

  constructor(
    private clientService: ClientService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getClient(this.route.snapshot.params["id"]);

    }
  }

  getClient(id: any): void {
    this.clientService.get(id)
      .subscribe({
        next: (data) => {
          this.currentClient = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  

  updateClient(): void {
    this.message = '';

    this.clientService.update(this.currentClient.id, this.currentClient)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message ? res.message : 'This client was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteClient(): void {
    this.clientService.delete(this.currentClient.id)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/client']);
        },
        error: (e) => console.error(e)
      });
  }
}
