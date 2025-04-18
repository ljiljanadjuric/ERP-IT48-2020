import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../../models/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUri='https://localhost:4430';
  constructor(private httpClient:HttpClient,
    private cookieService: CookieService
  ) { }

  signIn(body: any):Observable<any>
  {
    return this.httpClient.post<any>(this.baseUri+'/api/Autorizacija/login', body);
  }

  signUp(body: any):Observable<any>
  {
    body.tip = 1; //Klijent
    return this.httpClient.post<any>(this.baseUri+'/api/Autorizacija/register', body);
  }

  saveToken(token: string) {
    const now = new Date();
    now.setTime(now.getTime() + (10 * 60 * 1000));
    this.cookieService.set('token', token, { expires: now });
  }

  deleteToken() {
    this.cookieService.delete('token');
  }

  getToken(): string | null {
    return this.cookieService.get('token');
  }
}
