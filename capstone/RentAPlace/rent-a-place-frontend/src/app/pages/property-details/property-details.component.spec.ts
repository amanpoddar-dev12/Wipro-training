import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { PropertyDetailsComponent } from './property-details.component';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('PropertyDetailsComponent', () => {
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, RouterTestingModule, PropertyDetailsComponent],
      providers: [
        { provide: ActivatedRoute, useValue: { snapshot: { paramMap: { get: () => '1' } } } }
      ]
    }).compileComponents();

    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should fetch property details on init', () => {
    const fixture = TestBed.createComponent(PropertyDetailsComponent);
    const component = fixture.componentInstance;
    fixture.detectChanges();

    const req = httpMock.expectOne('http://localhost:5101/api/properties/1');
    expect(req.request.method).toBe('GET');

    req.flush({
      propertyId: 1,
      title: 'Beach Villa',
      location: 'Goa',
      pricePerNight: 5000,
      rating: 4.8,
      images: 'img1.jpg,img2.jpg'
    });

    expect(component.property.title).toBe('Beach Villa');
    expect(component.images.length).toBe(2);
  });
});
