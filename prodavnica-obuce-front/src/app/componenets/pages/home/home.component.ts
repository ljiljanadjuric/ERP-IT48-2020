import { Component, ViewChild } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Proizvod } from '../../../models/Proizvod';
import { Subscription } from 'rxjs';
import { RouterModule } from '@angular/router';
import { ProductService } from '../../../services/prooduct/product.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-home',
  imports: [MatCardModule, MatPaginatorModule, RouterModule, CommonModule, MatButtonModule, MatIconModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {



  products:Proizvod[]=[];
  filteredProducts: Proizvod[] = [];
  searchText!: string;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private productService: ProductService) {
  }

  ngOnInit(): void {

    this.productService.getProizvodi()
    .subscribe({
      next: (successResponse) => {
        this.products=successResponse;
        this.filteredProducts = this.products;
        this.updatePagination();
      },
      error: (error) => {
        console.log(error)
      }
    }
    );
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe((event: PageEvent) => {
      this.updatePagination();
    });
  }

  onPageChange(event: PageEvent): void {
    this.paginator.pageSize = event.pageSize;
    this.paginator.pageIndex = event.pageIndex;
    this.updatePagination();
  }

  updatePagination(): void {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    const endIndex = startIndex + this.paginator.pageSize;
    this.filteredProducts = this.products.slice(startIndex, endIndex);
  }

}
