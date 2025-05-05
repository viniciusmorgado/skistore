import { Routes } from '@angular/router';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/shop/product-details/product-details.component';
import { ErrorsComponent } from './features/errors/errors.component';

export const routes: Routes = [
    {path: '', component: ShopComponent},
    {path: 'shop', component: ShopComponent},
    {path: 'shop/:id', component: ProductDetailsComponent},
    {path: 'test-error', component: ErrorsComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
