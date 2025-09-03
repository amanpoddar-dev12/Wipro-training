import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, HomeComponent] // 👈 Import HomeComponent
    }).compileComponents();

    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); 
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(HomeComponent);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

 it('should fetch properties on init', () => {
  const fixture = TestBed.createComponent(HomeComponent);
  const component = fixture.componentInstance;

  fixture.detectChanges(); // calls ngOnInit

  const req = httpMock.expectOne('http://localhost:5101/api/properties');
  expect(req.request.method).toBe('GET');

  req.flush([
    { propertyId: 1, title: 'Test Villa', location: 'Goa', pricePerNight: 2000, rating: 4.5, images: 'img1.jpg' }
  ]);

  expect(component.properties.length).toBe(1);
  expect(component.properties[0].title).toBe('Test Villa');
});

});
