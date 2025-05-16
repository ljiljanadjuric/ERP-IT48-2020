import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { CartService } from '../../../../services/cart/cart.service';

@Component({
  selector: 'app-payment-successful',
  imports: [MatCardModule, MatIconModule, MatButtonModule, RouterModule],
  templateUrl: './payment-successful.component.html',
  styleUrl: './payment-successful.component.scss'
})
export class PaymentSuccessfulComponent implements OnInit {

  cartService = inject(CartService)

  ngOnInit(): void {
    this.cartService.removeAll()
  }
}
