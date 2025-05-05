import { Component, inject, OnInit } from '@angular/core';
import { ShopComponent } from '../shop.component';
import { ShopService } from '../../../core/services/shop/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../shared/models/product';

@Component({
  selector: 'app-product-details',
  imports: [],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})

export class ProductDetailsComponent implements OnInit {
  private shopService = inject(ShopService);
  private activatedRoute = inject(ActivatedRoute);
  product?: Product;
  
  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id'); // id = :id in app.routes.ts
    if (!id) return;
    this.shopService.getProduct(+id).subscribe({
      next: product => this.product = product,
      error: error => console.log(error)
    });
  }
}
