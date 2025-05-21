import { Component, inject, OnInit } from '@angular/core';
import { StavkaKorpe } from '../../../models/StavkaKorpe';
import { CartService } from '../../../services/cart/cart.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { PaymentService } from '../../../services/payment/payment.service';
import { Router } from '@angular/router';
import { StripeService } from '../../../services/payment/stripe.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cart',
  imports: [CommonModule, MatButtonModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss'
})
export class CartComponent implements OnInit {
  showDataNotFound = true;
  iznos:number|undefined;
  productsInCart: StavkaKorpe[] = []; // Array to store products in the cart
  // Not Found Message
  messageTitle = "No Products Found in Cart";
  messageDescription = "Please, Add Products to Cart";

  cartsService = inject(CartService)
  paymentService = inject(PaymentService)
  stripeService = inject(StripeService)
  router = inject(Router)
  toastr = inject(ToastrService)

  ngOnInit(): void {
    this.productsInCart = this.cartsService.getAll();
  }

  incrementQuantity(proizvodUk: StavkaKorpe): void {
    if (proizvodUk.kolicina < proizvodUk.proizvod.kolicina) {
      this.cartsService.increment(proizvodUk.proizvod)
    }
  }

  decrementQuantity(proizvodUk: StavkaKorpe): void {
    if (proizvodUk.kolicina > 1) {
      this.cartsService.decrement(proizvodUk.proizvod)
    }
  }

  removeProduct(proizvodUk: StavkaKorpe) {
    this.cartsService.remove(proizvodUk.proizvod)
    this.productsInCart = this.cartsService.getAll();
  }

  getTotal() {
    let sum = 0;
    this.productsInCart.forEach(x => sum += x.proizvod.prodajnaCena * x.kolicina)
    return sum;
  }

  payCash() {
    this.paymentService.payCash(this.productsInCart)
    .subscribe({
      next: (val) => {
        this.cartsService.removeAll()
        this.router.navigate(['/order-successful'])
      },
      error: (err) => {
        console.log(err)
        this.toastr.error('Porudzina nije sacuvana.')
      }
    })
  }

  payCard() {
    this.stripeService.checkout(this.productsInCart)
  }
}
