import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

// 👇 You’ll later create OwnerDashboardComponent & UserPropertiesComponent
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
  { path: '', component: HomeComponent },
  { path: 'selected-properties', component: SelectedPropertiesComponent },
   { path: 'search', component: SearchComponent },
  { path: 'property/:id', component: PropertyDetailsComponent },
  { path: 'my-reservations', component: MyReservationsComponent, canActivate: [roleGuard(['User'])] },
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
    { path: 'my-reservations', component: MyReservationsComponent },

  { path: 'my-properties', component: MyPropertiesComponent },
    { path: 'owner-reservations', component: OwnerReservationsComponent },
  // Owner only
  { path: 'owner-dashboard', component: OwnerDashboardComponent, canActivate: [roleGuard(['Owner'])] },

  // User only (browse properties + reservations)
  { path: 'properties', component: UserPropertiesComponent, canActivate: [roleGuard(['User'])] },
    { path: 'user-inbox', component: UserInboxComponent },
  { path: 'owner-inbox', component: OwnerInboxComponent }
];
