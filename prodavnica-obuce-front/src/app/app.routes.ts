import { Routes } from '@angular/router';
import { HomeComponent } from './componenets/pages/home/home.component';
import { SignInComponent } from './componenets/pages/sign-in/sign-in.component';
import { SignUpComponent } from './componenets/pages/sign-up/sign-up.component';
import { authGuard } from './guards/auth-guard';
import { CartComponent } from './componenets/pages/cart/cart.component';
import { OrderSuccessfulComponent } from './componenets/pages/orders/order-successful/order-successful.component';
import { PaymentSuccessfulComponent } from './componenets/pages/orders/payment-successful/payment-successful.component';
import { ProductsComponent } from './componenets/pages/products/products.component';

export const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [authGuard] },
    { path: 'cart', component: CartComponent, canActivate: [authGuard] },
    { path: 'products', component: ProductsComponent, canActivate: [authGuard] },
    { path: 'order-successful', component: OrderSuccessfulComponent, canActivate: [authGuard] },
    { path: 'payment-successful', component: PaymentSuccessfulComponent, canActivate: [authGuard] },
    { path: 'sign-in', component: SignInComponent },
    { path: 'sign-up', component: SignUpComponent },
    { path: '**', redirectTo: '' },
];
