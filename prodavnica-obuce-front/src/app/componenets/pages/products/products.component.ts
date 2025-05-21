import { Component, inject, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product/product.service';
import { ToastrService } from 'ngx-toastr';
import { Proizvod } from '../../../models/Proizvod';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  imports: [MatTableModule, MatButtonModule, MatProgressSpinnerModule, CommonModule ],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {

    isLoading = true;
    displayedColumns = ['id', 'ime', 'brend', 'boja', 'prodajnaCena', 'kolicina'];
    dataSource = new MatTableDataSource<Proizvod>();
    dialog = inject(MatDialog)
    service = inject(ProductService)
    toastr = inject(ToastrService)
  
    ngOnInit() {
      this.service.getProizvodiAdmin().subscribe(data => {
        this.dataSource.data = data
        this.isLoading = false
      });
    }

  
    addNew() {
      const dialogRef = this.dialog.open(ProductDialogComponent, {
        width: '400px',
        data: {}
      });
    
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.service.add(result).subscribe({
            next: (val) => {
              console.log(val)
              this.service.getProizvodiAdmin().subscribe(data => this.dataSource.data = data);
              this.toastr.success('Proizvod dodat');
            },
            error: (err) => {
              console.log(err)
            }
          });
        }
      });
    }
  }