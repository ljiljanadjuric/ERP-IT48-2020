import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { loadStripe, Stripe } from '@stripe/stripe-js';
import { StavkaKorpe } from '../../models/StavkaKorpe';

@Injectable({
  providedIn: 'root'
})
export class StripeService {

  private stripe: Promise<Stripe | null>;
  private apiUrl = 'https://localhost:4430';
  http = inject(HttpClient)

  constructor() {
    this.stripe = loadStripe('pk_test_51R9ie5DOf3Orfno9SwtRSOn8DnPKxVsuhc3YGJRx2UuBIspRvqnTonFjTNCwxMBSkCrgOpx15DzSrNPDdRBNAtHb0047KubRlp');
  }

  async checkout(cartItems: StavkaKorpe[]) {
    const body = {
      stavkeProdaje: cartItems.map(x => {
        return {
          idProizvoda: x.proizvod.id,
          kolicina: x.kolicina
        }
      }),
      nacinPlacanja: 1
    }

    const stripe = await this.stripe;
    this.http.post<{ sessionId: string }>(`${this.apiUrl}/api/Klijent/Card`, body)
      .subscribe(async response => {
        if (stripe) {
          await stripe.redirectToCheckout({ sessionId: response.sessionId });
        }
      });
  }
}
