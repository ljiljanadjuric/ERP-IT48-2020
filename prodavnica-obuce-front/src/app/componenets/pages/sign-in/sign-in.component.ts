import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AuthService } from '../../../services/auth/auth.service';

@Component({
  selector: 'app-sign-in',
  imports: [MatCardModule, MatFormFieldModule, ReactiveFormsModule, CommonModule, MatButtonModule, MatInputModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss'
})
export class SignInComponent {

  constructor(
    private authService: AuthService
  ) {

  }

  form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    sifra: new FormControl('', Validators.required),
  });

  submit() {
    if (this.form.valid) {
      this.authService.signIn(this.form.value).subscribe(
        {
          next: (response: any) => {
            this.authService.saveToken(response.token);
            this.authService.saveRole(response.role);
            if (response.role === 'Admin') {
              window.location.href = '/products'
            } else 
              window.location.href = '/'
          },
          error: (err) => {
            console.log(err)
          }
        }
      )
    } 
  }
}
