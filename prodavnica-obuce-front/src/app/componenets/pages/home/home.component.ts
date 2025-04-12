import { Component, ViewChild } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Proizvod } from '../../../models/Proizvod';
import { debounceTime, distinctUntilChanged, Subscription, switchMap } from 'rxjs';
import { RouterModule } from '@angular/router';
import { ProductService } from '../../../services/product/product.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [MatCardModule, MatPaginatorModule, RouterModule, CommonModule, MatButtonModule, MatIconModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  searchControl = new FormControl('')

  products:Proizvod[]=[];
  filteredProducts: Proizvod[] = [];
  searchText!: string;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private productService: ProductService) {

      this.searchControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap(value => this.fetchFilteredProducts(value)) // Call API
      )
      .subscribe(products => {
        this.products = products;
        this.filteredProducts = this.products;
        this.updatePagination();
      });
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

  fetchFilteredProducts(searchText:string | null) {
    if (searchText)
      return this.productService.getFiltriraniProizvodi(searchText);
    else 
      return this.productService.getProizvodi();
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
