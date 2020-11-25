import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransportCardRegisterComponent } from './transport-card-register.component';

describe('TransportCardRegisterComponent', () => {
  let component: TransportCardRegisterComponent;
  let fixture: ComponentFixture<TransportCardRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransportCardRegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransportCardRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
