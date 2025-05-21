import { inject } from '@angular/core';
import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from '../services/auth/auth.service';
import { catchError, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const authService = inject(AuthService);
    const toastr = inject(ToastrService)
    const token = authService.getToken();
    const router = inject(Router)
    
    if (token) {
        req = req.clone({
        setHeaders: {
            Authorization: `Bearer ${token}`
        }
        });
    }
    
    return next(req).pipe(

        catchError((error: HttpErrorResponse) => {
          if (error.status === 401) {
            toastr.error('Molimo ulogujte se ponovo', 'Sesija je istekla');
            router.navigate(['/'])
          }
  
          return throwError(() => error);
        })
      );
    };
