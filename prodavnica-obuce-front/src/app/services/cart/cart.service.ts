import { Injectable } from '@angular/core';
import { StavkaKorpe } from '../../models/StavkaKorpe';
import { Proizvod } from '../../models/Proizvod';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems: StavkaKorpe[] = []

  constructor() {
    const storedCart = localStorage.getItem('cart');
    this.cartItems = storedCart ? JSON.parse(storedCart) : []
  }

  addToCart(product: Proizvod) {
    
    if (this.cartItems.find(x => x.proizvod.id === product.id)) {
      this.cartItems.find(x => x.proizvod.id === product.id)!.kolicina++;
    } else {
      this.cartItems.push({
        kolicina: 1,
        proizvod: product
      })
    }

    localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }

  getAll() {
    return this.cartItems;
  }

  increment(product: Proizvod) {
    const item = this.cartItems.find(x => x.proizvod.id === product.id)
    item!.kolicina++;
    localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }

  decrement(product: Proizvod) {
    const item = this.cartItems.find(x => x.proizvod.id === product.id)
    item!.kolicina--;
    localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }

  remove(product: Proizvod) {
    this.cartItems = this.cartItems.filter(x => x.proizvod.id !== product.id);
    localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }
}
