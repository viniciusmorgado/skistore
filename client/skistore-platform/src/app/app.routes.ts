import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/shop/product-details/product-details.component';

export const routes: Routes = [
    {path: '', component: ShopComponent},
    {path: 'shop', component: ShopComponent},
    {path: 'shop/:id', component: ProductDetailsComponent},
    // TODO: Probably is better to change for a error page
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
