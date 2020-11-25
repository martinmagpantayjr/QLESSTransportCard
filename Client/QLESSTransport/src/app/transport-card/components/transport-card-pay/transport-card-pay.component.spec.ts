import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransportCardPayComponent } from './transport-card-pay.component';

describe('TransportCardPayComponent', () => {
  let component: TransportCardPayComponent;
  let fixture: ComponentFixture<TransportCardPayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransportCardPayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransportCardPayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
