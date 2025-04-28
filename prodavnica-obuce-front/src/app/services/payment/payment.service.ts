import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StavkaKorpe } from '../../models/StavkaKorpe';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private baseUri='https://localhost:4430';
  constructor(private httpClient:HttpClient) { }

  payCash(cartItems: StavkaKorpe[]) {
    const body = {
      stavkeProdaje: cartItems.map(x => {
        return {
          idProizvoda: x.proizvod.id,
          kolicina: x.kolicina
        }
      }),
      nacinPlacanja: 0
    }
    console.log(body)
    return this.httpClient.post<any>(this.baseUri+'/api/Klijent/Cash', body);
  }

  payCard(cartItems: StavkaKorpe[]) {
    const body = {
      stavkeProdaje: cartItems.map(x => {
        return {
          idProizvoda: x.proizvod.id,
          kolicina: x.kolicina
        }
      }),
      nacinPlacanja: 1
    }
    return this.httpClient.post<string>(this.baseUri+'/api/Klijent/Card', body);
  }
}
