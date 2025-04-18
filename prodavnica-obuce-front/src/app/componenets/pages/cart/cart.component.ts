import { Component, OnInit } from '@angular/core';
import { StavkaKorpe } from '../../../models/StavkaKorpe';
import { CartService } from '../../../services/cart/cart.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

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

  constructor(private cartsService: CartService) {}

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

}
