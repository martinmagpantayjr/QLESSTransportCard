import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransportCardPurchaseComponent } from './transport-card-purchase.component';

describe('TransportCardPurchaseComponent', () => {
  let component: TransportCardPurchaseComponent;
  let fixture: ComponentFixture<TransportCardPurchaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransportCardPurchaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransportCardPurchaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
