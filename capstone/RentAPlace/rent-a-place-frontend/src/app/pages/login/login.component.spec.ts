import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from '../../services/auth.service';

describe('LoginComponent', () => {
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, FormsModule, RouterTestingModule, LoginComponent],
      providers: [AuthService]
    }).compileComponents();

    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should login successfully', () => {
    const fixture = TestBed.createComponent(LoginComponent);
    const component = fixture.componentInstance;

    component.email = 'test@example.com';
    component.password = 'password';
    fixture.detectChanges();

    component.login();

    // ✅ Intercept the request
    const req = httpMock.expectOne('http://localhost:5101/api/auth/login');
    expect(req.request.method).toBe('POST');

    req.flush({ token: 'abc123', role: 'User', name: 'Test User' });

    expect(localStorage.getItem('token')).toBe('abc123');
  });
});
