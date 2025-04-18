import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  imports: [MatIconModule, MatToolbarModule, MatButtonModule, FormsModule, MatTooltipModule, RouterModule, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
 
  authService = inject(AuthService);
  searchText = ''
  isLogged = false

  ngOnInit(): void {
    const token = this.authService.getToken()
    if (token) this.isLogged = true;
  }

  signOut() {
    this.authService.deleteToken()
    console.log(window.location.pathname)
    if (window.location.pathname === '/')
    window.location.href = '/'
  }
}
