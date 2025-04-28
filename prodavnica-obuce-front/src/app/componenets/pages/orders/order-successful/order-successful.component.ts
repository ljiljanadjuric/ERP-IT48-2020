import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-order-successful',
  imports: [MatCardModule, MatIconModule, MatButtonModule, RouterModule],
  templateUrl: './order-successful.component.html',
  styleUrl: './order-successful.component.scss'
})
export class OrderSuccessfulComponent {

}
