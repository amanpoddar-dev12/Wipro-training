import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');

  // ✅ List of public endpoints
  const publicEndpoints = [
    '/api/properties/top-rated',
    '/api/properties/search',
    '/api/properties',         // general list
    '/api/properties/'         // single property by id
  ];

  // Check if the request matches a public endpoint
  const isPublic = publicEndpoints.some(url => req.url.includes(url));

  if (token && !isPublic) {
    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(cloned);
  }

  // For public requests → no token
  return next(req);
};
