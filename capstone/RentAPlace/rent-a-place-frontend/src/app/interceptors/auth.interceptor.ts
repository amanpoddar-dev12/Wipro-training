import { Injectable } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';

// ✅ Functional interceptor (Angular 16+ way)
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');

  if (token) {
    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(cloned);
  }

  return next(req);
};
