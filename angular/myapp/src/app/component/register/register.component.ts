import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  standalone: true, 
  imports: [],
  template: `
   <div class="container mt-5">
  <div class="row justify-content-center">
    <div class="col-md-6">
      <div class="card shadow-lg border-0 rounded">
        <div class="card-body p-4">
          <h2 class="text-center mb-4">Register</h2>
          <p class="text-center text-muted">Create your account below</p>
          <form>
            <div class="mb-3">
              <label for="username" class="form-label">Username</label>
              <input 
                type="text" 
                class="form-control" 
                id="username" 
                placeholder="Enter username">
            </div>
            <div class="mb-3">
              <label for="email" class="form-label">Email</label>
              <input 
                type="email" 
                class="form-control" 
                id="email" 
                placeholder="Enter email">
            </div>
            <div class="mb-3">
              <label for="password" class="form-label">Password</label>
              <input 
                type="password" 
                class="form-control" 
                id="password" 
                placeholder="Enter password">
            </div>
            <button type="submit" class="btn btn-primary w-100">Register</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</div>
  `,
  styleUrls: ['./register.component.css'] 
})
export class RegisterComponent { }
