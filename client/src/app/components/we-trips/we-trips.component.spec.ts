import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeTripsComponent } from './we-trips.component';

describe('WeTripsComponent', () => {
  let component: WeTripsComponent;
  let fixture: ComponentFixture<WeTripsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeTripsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeTripsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
