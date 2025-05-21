import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AuthService } from '../../../services/auth/auth.service';
import { Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sign-up',
  imports: [MatCardModule, MatFormFieldModule, ReactiveFormsModule, CommonModule, MatButtonModule, MatInputModule, RouterModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {

  authService = inject(AuthService)
  router = inject(Router)
  toastr = inject(ToastrService)

  form: FormGroup = new FormGroup({
    korisnickoIme: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    sifra: new FormControl('', Validators.required),
    ime: new FormControl('', Validators.required),
    prezime: new FormControl('', Validators.required),
    adresa: new FormControl('', Validators.required),
    brojTelefona: new FormControl(''),
  });

  submit() {
    if (this.form.valid) {
      this.authService.signUp(this.form.value).subscribe(
        {
          next: (val) => {
            this.toastr.success('Uspesna registracija')
            this.router.navigate(['/'])
          },
          error: (err) => {
            this.toastr.error('Koristite postojece korisnicko ime ili imejl')
          }
        }
      )
    } 
  }
}
