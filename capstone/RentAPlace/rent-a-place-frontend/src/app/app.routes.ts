import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

import { OwnerDashboardComponent } from './pages/owner-dashboard/owner-dashboard.component';
import { UserPropertiesComponent } from './pages/user-properties/user-properties.component';
import { PropertyDetailsComponent } from './pages/property-details/property-details.component';
import { MyReservationsComponent } from './pages/my-reservations/my-reservations.component';
import { SearchComponent } from './pages/search/search.component';
import { SelectedPropertiesComponent } from './pages/selected-properties/selected-properties.component';
import { MyPropertiesComponent } from './pages/my-properties/my-properties.component';
import { OwnerReservationsComponent } from './pages/owner-reservations/owner-reservations.component';
import { UserInboxComponent } from './pages/user-inbox/user-inbox.component';
import { OwnerInboxComponent } from './pages/owner-inbox/owner-inbox.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' }, // ✅ redirect root to home
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  { path: 'selected-properties', component: SelectedPropertiesComponent, canActivate: [authGuard] },
  { path: 'search', component: SearchComponent, canActivate: [authGuard] },
  { path: 'property/:id', component: PropertyDetailsComponent, canActivate: [authGuard] },
  { path: 'my-reservations', component: MyReservationsComponent, canActivate: [roleGuard(['User'])] },
  { path: 'my-properties', component: MyPropertiesComponent, canActivate: [roleGuard(['Owner'])] },
  { path: 'owner-reservations', component: OwnerReservationsComponent, canActivate: [roleGuard(['Owner'])] },
  { path: 'owner-dashboard', component: OwnerDashboardComponent, canActivate: [roleGuard(['Owner'])] },
  { path: 'properties', component: UserPropertiesComponent, canActivate: [roleGuard(['User'])] },
  { path: 'user-inbox', component: UserInboxComponent, canActivate: [authGuard] },
  { path: 'owner-inbox', component: OwnerInboxComponent, canActivate: [authGuard] },

  { path: '**', redirectTo: 'login' } // fallback
];
