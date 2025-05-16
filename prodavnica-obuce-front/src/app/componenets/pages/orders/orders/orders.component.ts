import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from '../../../../services/order/order.service';
import { Porudzbina } from '../../../../models/Porudzbina';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders',
  imports: [MatTableModule, MatButtonModule, CommonModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent {
  displayedColumns = ['id', 'vremeProdaje', 'cenaProdaje', 'nacinPlacanja', 'kupac', 'placeno'];
  dataSource = new MatTableDataSource<Porudzbina>();
  dialog = inject(MatDialog)
  service = inject(OrderService)
  toastr = inject(ToastrService)

  ngOnInit() {
    this.service.getProdaje().subscribe(data => this.dataSource.data = data);
  }

}