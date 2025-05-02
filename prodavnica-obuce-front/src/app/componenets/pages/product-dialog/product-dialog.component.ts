import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Proizvod } from '../../../models/Proizvod';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-product-dialog',
  imports: [MatFormFieldModule, MatInputModule, MatDialogModule, ReactiveFormsModule, MatButtonModule],
  templateUrl: './product-dialog.component.html',
  styleUrl: './product-dialog.component.scss'
})
export class ProductDialogComponent {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ProductDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Proizvod
  ) {
    this.form = this.fb.group({
      id: [data?.id || 0],
      ime: [data?.ime || '', Validators.required],
      brend: [data?.brend || '', Validators.required],
      boja: [data?.boja || '', Validators.required],
      prodajnaCena: [data?.prodajnaCena || 0, [Validators.required, Validators.min(0)]],
      kolicina: [data?.kolicina || 0, [Validators.required, Validators.min(0)]]
    });
  }

  onSave() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

  onCancel() {
    this.dialogRef.close();
  }

}
