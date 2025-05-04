import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../core/services/shop/shop.service';
import { Product } from '../../shared/models/product';
import { ProductItemComponent } from "./product-item/product-item.component";
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-shop',
  imports: [
    ProductItemComponent,
    MatButton,
    MatIcon
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})

export class ShopComponent implements OnInit {
  products: Product[] = [];
  selectedBrands: string[] = [];
  selectedTypes: string[] = [];
  
  private dialogService = inject(MatDialog);
  private shopService = inject(ShopService);

  ngOnInit(): void {
    this.initializeShop();
  }

  initializeShop() {
    this.shopService.getBrands();
    this.shopService.getTypes();
    this.shopService.getProducts().subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error),
    });
  }

  openFiltersDialog() {
    const dialogRef = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedBrands: this.selectedBrands,
        selectedTypes: this.selectedTypes 
      }
    });
    
    dialogRef.afterClosed().subscribe({
      next: result => {
        if (result) {
          console.log(result);
          this.selectedBrands = result.selectedBrands;
          this.selectedTypes = result.selectedTypes;
          this.shopService.getProducts(this.selectedBrands, this.selectedTypes).subscribe({
            next: response => this.products = response.data,
            error: error => console.log(error)
          })
        }
      }
    })
  }
}
