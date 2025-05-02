import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Proizvod } from '../../models/Proizvod';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUri='https://localhost:4430';
  constructor(private httpClient:HttpClient) { }

  getProizvodi():Observable<Proizvod[]> {
    return this.httpClient.get<Proizvod[]>(this.baseUri+'/api/Klijent/products');
  }

  getProizvodiAdmin():Observable<Proizvod[]> {
    return this.httpClient.get<Proizvod[]>(this.baseUri+'/api/Zaposleni/products');
  }

  getFiltriraniProizvodi(searchText: string):Observable<Proizvod[]> {
    return this.httpClient.get<Proizvod[]>(this.baseUri+'/api/Klijent/filtirrani-proizvodi?brend=' + searchText);
  }

  getProizvod(idProizvoda: number): Observable<Proizvod>{
    return this.httpClient.get<Proizvod>(this.baseUri+'/api/Proizvod/'+idProizvoda)
  }
  getCartProducts(userId: string): Observable<Proizvod[]> {
    return this.httpClient.get<Proizvod[]>(`${this.baseUri}/api/cart/${userId}/products`);
  }

  add(proizvod: Proizvod): Observable<any> {
    return this.httpClient.post<any>(`${this.baseUri}/api/Zaposleni/proizvodi`, {
      ...proizvod,
      cena: proizvod.prodajnaCena
    });
  }

  update(proizvod: Proizvod): Observable<any> {
    return this.httpClient.patch<any>(`${this.baseUri}/api/Zaposleni/proizvodi`, {
      ...proizvod,
      cena: proizvod.prodajnaCena
    });
  }
}
