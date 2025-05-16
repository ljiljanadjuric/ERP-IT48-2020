import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Porudzbina } from '../../models/Porudzbina';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private baseUri='https://localhost:4430';
  constructor(private httpClient:HttpClient) { }

  getProdaje():Observable<Porudzbina[]> {
    return this.httpClient.get<Porudzbina[]>(this.baseUri+'/api/Zaposleni/prodaje');
  }
}
