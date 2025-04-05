import { Routes } from '@angular/router';
import { HomeComponent } from './componenets/pages/home/home.component';
import { SignInComponent } from './componenets/pages/sign-in/sign-in.component';
import { SignUpComponent } from './componenets/pages/sign-up/sign-up.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'sign-in', component: SignInComponent },
    { path: 'sign-up', component: SignUpComponent },
    { path: '**', redirectTo: '' },
];
