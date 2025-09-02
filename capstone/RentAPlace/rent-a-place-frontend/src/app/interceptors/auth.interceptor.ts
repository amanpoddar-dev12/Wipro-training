import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');

  // ✅ Only these are public
  const publicEndpoints = [
    '/api/auth/login',
    '/api/auth/register',
    '/api/properties/top-rated',
    '/api/properties/search',
    '/api/properties' // ONLY the list of all properties
  ];

  // Check exact matches (not "includes")
  const isPublic = publicEndpoints.some(url => req.url.endsWith(url));

  if (token && !isPublic) {
    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(cloned);
  }

  return next(req);
};
